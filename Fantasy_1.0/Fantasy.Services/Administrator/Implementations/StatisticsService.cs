using Fantasy.Common;
using Fantasy.Common.Attributes;
using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models.Statistics;
using Fantasy.Services.Models;
using Fantasy.Services.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Fantasy.Services.Administrator.Models;

namespace Fantasy.Services.Administrator.Implementations
{
    using static DataConstants;
    using static GlobalConstants;

    public class StatisticsService : IStatisticsService 
    {
        //todo add to global constants

        private readonly FantasyDbContext db;

        public StatisticsService(FantasyDbContext db)
        {
            this.db = db;
        }


        public async Task<TModel> GetStatisticsAsync<TModel>(int playerId, int gameweekId)
        {
            return new StatisticsServiceModel
                {
                    Goalkeeping = await  this.db.FindAsync<GoalkeepingStatistics>(playerId, gameweekId),
                    Discipline = await this.db.FindAsync<DisciplineStatistics>(playerId, gameweekId),
                    TeamPlay =  await this.db.FindAsync<TeamPlayStatistics>(playerId, gameweekId),
                    Defence =  await this.db.FindAsync<DefenceStatistics>(playerId, gameweekId),
                    Attack =  await this.db.FindAsync<AttackStatistics>(playerId, gameweekId),
                    Match =  await this.db.FindAsync<MatchStatistics>(playerId, gameweekId),
                }
                .To<TModel>();
        }
        //todo refactor Must!
        public async Task<int> EditPlayerStatisticsAsync(FootballPlayerStatisticsServiceModel model)
        {
           var goalkeeping = await this.db.FindAsync<GoalkeepingStatistics>(model.MatchPlayerId, model.MatchGameweekId);
           var discipline = await this.db.FindAsync<DisciplineStatistics>(model.MatchPlayerId, model.MatchGameweekId);
           var teamPlay = await this.db.FindAsync<TeamPlayStatistics>(model.MatchPlayerId, model.MatchGameweekId);
           var defence = await this.db.FindAsync<DefenceStatistics>(model.MatchPlayerId, model.MatchGameweekId);
           var attack = await this.db.FindAsync<AttackStatistics>(model.MatchPlayerId, model.MatchGameweekId);
           var match = await this.db.FindAsync<MatchStatistics>(model.MatchPlayerId, model.MatchGameweekId);

           match.Appearances = model.MatchAppearances;
           match.Losses = model.MatchLosses;
           match.Wins = match.Wins;
           
           attack.BigChancesMissed = model.AttackBigChancesMissed;
           attack.FreeKicksScored = model.AttackFreeKicksScored;
           attack.Goals = model.AttackGoals;
           attack.HitWoodwork = model.AttackHitWoodwork;
           attack.PenaltiesScored = model.AttackPenaltiesScored;
           attack.Shots = model.AttackPenaltiesScored;
           attack.ShotsOnTarget = model.AttackShotsOnTarget;

           defence.AerialBattlesLost = model.DefenceAerialBattlesLost;
           defence.AerialBattlesWon = model.DefenceAerialBattlesWon;
           defence.BlockedShots = model.DefenceBlockedShots;
           defence.CleanSheets = model.DefenceCleanSheets;
           defence.Clearances = model.DefenceClearances;
           defence.DuelsLost = model.DefenceDuelsLost;
           defence.DuelsWon = model.DefenceDuelsWon;
           defence.ErrorsLeadingToGoal = model.DefenceErrorsLeadingToGoal;
           defence.GoalsConceded = model.DefenceGoalsConceded;
           defence.HeadedClearance = model.DefenceHeadedClearance;
           defence.LastManTackles = model.DefenceLastManTackles;
           defence.OwnGoals = model.DefenceOwnGoals;
           defence.Recoveries = model.DefenceRecoveries;
           defence.Tackles = model.DefenceTackles;
           defence.SuccessfulFiftyFifties = model.DefenceSuccessfulFiftyFifties;
           defence.Interceptions = model.DefenceInterceptions;

           teamPlay.AccurateLongBalls = model.TeamPlayAccurateLongBalls;
           teamPlay.Assists = model.TeamPlayAssists;
           teamPlay.BigChancesCreated = model.TeamPlayBigChancesCreated;
           teamPlay.Crosses = model.TeamPlayCrosses;
           teamPlay.Passes = model.TeamPlayPasses;
           teamPlay.ThroughBalls = model.TeamPlayThroughBalls;

           discipline.Fouls = model.DisciplineFouls;
           discipline.Offsides = model.DisciplineFouls;
           discipline.RedCards = model.DisciplineRedCards;
           discipline.YellowCards = model.DisciplineYellowCards;

           goalkeeping.Catches = model.GoalkeepingCatches;
           goalkeeping.GoalKicks = model.GoalkeepingGoalKicks;
           goalkeeping.HighClaims = model.GoalkeepingHighClaims;
           goalkeeping.PenaltiesSaved = model.GoalkeepingPenaltiesSaved;
           goalkeeping.Saves = model.GoalkeepingSaves;
           goalkeeping.SweeperClearances = model.GoalkeepingSweeperClearances;
           goalkeeping.Punches = model.GoalkeepingPunches;

           var result = await this.db.SaveChangesAsync();

           return result;
        }

        public async Task<string> UpdateFootballPlayersPointsAsync(int gameweekId)
        {
            var players = await this.db.FootballPlayers
                .Include(p => p.FootballPlayerPosition)
                .Include(p => p.GameweekPoints)
                .ToListAsync();

            foreach (var player in players)
            {
                IHaveStatistics statistics;
                var points = 0;

                switch (player.FootballPlayerPosition.Name)
                {
                    case Goalkeeper:
                        statistics = await this.GetStatisticsAsync<GoalkeeperStatisticsServiceModel>(player.Id, gameweekId);
                        break;
                    case Defender:
                        statistics = await this.GetStatisticsAsync<DefenderStatisticsServiceModel>(player.Id, gameweekId);
                        break;
                    case Midfielder:
                        statistics = await this.GetStatisticsAsync<MidfielderStatisticsServiceModel>(player.Id, gameweekId);
                        break;
                    case Forward:
                        statistics = await this.GetStatisticsAsync<ForwardStatisticsServiceModel>(player.Id, gameweekId);
                        break;
                    default: return null;
                }

                statistics
                    .GetType()
                    .GetProperties()
                    .Where(p => p.PropertyType == typeof(short))
                    .ToList()
                    .ForEach(p => points += (short)p.GetValue(statistics) * p.GetCustomAttribute<PointsAttribute>().Units);

                player.GameweekPoints.First(x => x.GameweekId == gameweekId).Points = points;
            }

            var users = this.db.Users
                .Where(u => u.Squad.Count != 0)
                .Include(u => u.Squad)
                .ThenInclude(fp => fp.GameweekStatuses)
                .Include(u => u.GameweekScoreses)
                .ToList();

            var result = await this.db.SaveChangesAsync();

            foreach (var user in users)
            {
                var score = user.Squad
                    .Where(x => x.FantasyUser == user &&
                                x.GameweekStatuses.First(y => y.GameweekId == gameweekId).IsBenched == false)
                    .Sum(x => x.FootballPlayer.GameweekPoints.First(y => y.GameweekId == gameweekId).Points);

                user.GameweekScoreses.First(x => x.GameweekId == gameweekId).Score = score;
            }

            result += await this.db.SaveChangesAsync();

            return result.ToString();
        }


        //todo refactor
        public string Seed(int gameweekId)
        {
            if (this.db.MatchStatistics.Any(ms => ms.GameweekId == gameweekId))
            {
                return null;
            }

            //todo
            //export first!!!
            var result = string.Empty;
            var statisticsCollection = new List<BaseStatistics>();

            //todo update group of players only !!!
            var dbFootballPlayerIds = this.db.FootballPlayers
               // .Where(x => x.FootballClub.Id == 10)
                .Select(p => p.Id)
                .ToList();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            statisticsCollection = GetNewAllTimeStatisticsCollection(dbFootballPlayerIds);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);

            if (statisticsCollection.Count != dbFootballPlayerIds.Count * 6)
            {
                return "Something went wrong! Please Try again later";
            }

            this.db.RemoveRange(db.DefenceStatistics.Where(x => x.GameweekId == AllTimeStatisticsGameweekId));
            this.db.RemoveRange(db.TeamPlayStatistics.Where(x => x.GameweekId == AllTimeStatisticsGameweekId));
            this.db.RemoveRange(db.GoalkeepingStatistics.Where(x => x.GameweekId == AllTimeStatisticsGameweekId));
            this.db.RemoveRange(db.MatchStatistics.Where(x => x.GameweekId == AllTimeStatisticsGameweekId));
            this.db.RemoveRange(db.DisciplineStatistics.Where(x => x.GameweekId == AllTimeStatisticsGameweekId));
            this.db.RemoveRange(db.AttackStatistics.Where(x => x.GameweekId == AllTimeStatisticsGameweekId));

            result = "Records removed: " + this.db.SaveChanges();

            this.db.AddRange(statisticsCollection);

            result += " / New all time records added: " + this.db.SaveChanges();
            
            statisticsCollection = CreateNewGameweekStatistics(dbFootballPlayerIds, gameweekId);

            this.db.AddRange(statisticsCollection);

            result += " / New gameweek records added: " + this.db.SaveChanges();

            return result;
        }

        private List<BaseStatistics> GetNewAllTimeStatisticsCollection(List<int> dbFootballPlayerIds)
        {
            var statisticsPropertyRegex = new Regex("<span class=\"stat\">([A-Za-z\\ ]+)   <span.+\\s+([0-9\\.\\,]+)");
            var customStatisticsPropertyRegex = new Regex("<span class=\"stat\">(Successful 50/50s)   <span.+\\s+([0-9\\.\\,]+)");

            var statisticsCollection = new List<BaseStatistics>();

            foreach (var playerId in dbFootballPlayerIds)
            {
                Console.WriteLine(playerId);
                var properties = new Dictionary<string, string>();

                var responseFromServer = string.Empty;
                var url = $"https://www.premierleague.com/players/{playerId}/player/stats";

                var request = WebRequest.Create(url);
                request.Credentials = CredentialCache.DefaultCredentials;
                var response = request.GetResponse();

                using (var dataStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(dataStream);
                    responseFromServer = reader.ReadToEnd();

                    var customPropertyRegexMatch = customStatisticsPropertyRegex.Match(responseFromServer);
                    if (customPropertyRegexMatch.Length != 0)
                    {
                        properties.Add("SuccessfulFiftyFifties", customPropertyRegexMatch.Groups[2].ToString());
                    }

                    var propertyMatches = statisticsPropertyRegex.Matches(responseFromServer);
                    if (propertyMatches.Count == 0)
                    {
                        continue;
                    }

                    foreach (Match match in propertyMatches)
                    {
                        var propertyName = match.Groups[1].ToString().Replace(" ", "");
                        var propertyValue = match.Groups[2].ToString().Replace(",", "");

                        if (!properties.ContainsKey(propertyName))
                        {
                            properties.Add(propertyName, propertyValue);
                        }
                    }

                    var playerStatisticsCollection = new List<BaseStatistics>
                    {
                        new AttackStatistics(),
                        new MatchStatistics(),
                        new DefenceStatistics(),
                        new TeamPlayStatistics(),
                        new DisciplineStatistics(),
                        new GoalkeepingStatistics(),
                    };

                    foreach (var playerStatistics in playerStatisticsCollection)
                    {
                        playerStatistics.GameweekId = AllTimeStatisticsGameweekId;
                        playerStatistics.PlayerId = playerId;

                        foreach (var kvp in properties)
                        {
                            playerStatistics
                                .GetType()
                                .GetProperty(kvp.Key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                                ?.SetValue(playerStatistics, short.Parse(kvp.Value));
                        }
                    }

                    statisticsCollection.AddRange(playerStatisticsCollection);
                }

                response.Close();
            }

            return statisticsCollection;
        }

        //todo refactor
        private List<BaseStatistics> CreateNewGameweekStatistics(List<int> dbFootballPlayerIds, int gameweekId)
        {
            var statisticsCollection = new List<BaseStatistics>();

            foreach (var playerId in dbFootballPlayerIds)
            {
                var defenceAllTime = this.db.DefenceStatistics.First(x => x.GameweekId == AllTimeStatisticsGameweekId && x.PlayerId == playerId);
                var defenceSum = this.db.DefenceStatistics.Where(x => x.GameweekId != AllTimeStatisticsGameweekId && x.PlayerId == playerId).ToList();

                var matchAllTime = this.db.MatchStatistics.First(x => x.GameweekId == AllTimeStatisticsGameweekId && x.PlayerId == playerId);
                var matchSum = this.db.MatchStatistics.Where(x => x.GameweekId != AllTimeStatisticsGameweekId && x.PlayerId == playerId).ToList();

                var teamPlayAllTime = this.db.TeamPlayStatistics.First(x => x.GameweekId == AllTimeStatisticsGameweekId && x.PlayerId == playerId);
                var teamPlaySum = this.db.TeamPlayStatistics.Where(x => x.GameweekId != AllTimeStatisticsGameweekId && x.PlayerId == playerId).ToList();

                var attackAllTime = this.db.AttackStatistics.First(x => x.GameweekId == AllTimeStatisticsGameweekId && x.PlayerId == playerId);
                var attackSum = this.db.AttackStatistics.Where(x => x.GameweekId != AllTimeStatisticsGameweekId && x.PlayerId == playerId).ToList();

                var disciplineAllTime = this.db.DisciplineStatistics.First(x => x.GameweekId == AllTimeStatisticsGameweekId && x.PlayerId == playerId);
                var disciplineSum = this.db.DisciplineStatistics.Where(x => x.GameweekId != AllTimeStatisticsGameweekId && x.PlayerId == playerId).ToList();

                var goalkeepingAllTime = this.db.GoalkeepingStatistics.First(x => x.GameweekId == AllTimeStatisticsGameweekId && x.PlayerId == playerId);
                var goalkeepingSum = this.db.GoalkeepingStatistics.Where(x => x.GameweekId != AllTimeStatisticsGameweekId && x.PlayerId == playerId).ToList();

                short b = -4;
                short c = 0;
                var a = Math.Max(-b, c);

                var defenceStatistics = new DefenceStatistics
                {
                    SuccessfulFiftyFifties = (short) Math.Max(defenceAllTime.SuccessfulFiftyFifties - defenceSum.Sum(x => x.SuccessfulFiftyFifties), 0),
                    ErrorsLeadingToGoal = (short) Math.Max(defenceAllTime.ErrorsLeadingToGoal - defenceSum.Sum(x => x.ErrorsLeadingToGoal), 0),
                    AerialBattlesLost = (short) Math.Max(defenceAllTime.AerialBattlesLost - defenceSum.Sum(x => x.AerialBattlesLost), 0),
                    AerialBattlesWon = (short) Math.Max(defenceAllTime.AerialBattlesWon - defenceSum.Sum(x => x.AerialBattlesWon), 0),
                    HeadedClearance = (short) Math.Max(defenceAllTime.HeadedClearance - defenceSum.Sum(x => x.HeadedClearance), 0),
                    LastManTackles = (short) Math.Max(defenceAllTime.LastManTackles - defenceSum.Sum(x => x.LastManTackles), 0),
                    Interceptions = (short) Math.Max(defenceAllTime.Interceptions - defenceSum.Sum(x => x.Interceptions), 0),
                    GoalsConceded = (short) Math.Max(defenceAllTime.GoalsConceded - defenceSum.Sum(x => x.GoalsConceded), 0),
                    BlockedShots = (short) Math.Max(defenceAllTime.BlockedShots - defenceSum.Sum(x => x.BlockedShots), 0),
                    CleanSheets = (short) Math.Max(defenceAllTime.CleanSheets - defenceSum.Sum(x => x.CleanSheets), 0),
                    Clearances = (short) Math.Max(defenceAllTime.Clearances - defenceSum.Sum(x => x.Clearances), 0),
                    Recoveries = (short) Math.Max(defenceAllTime.Recoveries - defenceSum.Sum(x => x.Recoveries), 0),
                    DuelsLost = (short) Math.Max(defenceAllTime.DuelsLost - defenceSum.Sum(x => x.DuelsLost), 0),
                    DuelsWon = (short) Math.Max(defenceAllTime.DuelsWon - defenceSum.Sum(x => x.DuelsWon), 0),
                    OwnGoals = (short) Math.Max(defenceAllTime.OwnGoals - defenceSum.Sum(x => x.OwnGoals), 0),
                    Tackles = (short) Math.Max(defenceAllTime.Tackles - defenceSum.Sum(x => x.Tackles), 0),
                    PlayerId = playerId,
                    GameweekId = gameweekId,
                };

                var matchStatistics = new MatchStatistics
                {
                    Appearances = (short) Math.Max(matchAllTime.Appearances - matchSum.Sum(x => x.Appearances), 0),
                    Losses = (short) Math.Max(matchAllTime.Losses - matchSum.Sum(x => x.Losses), 0),
                    Wins = (short) Math.Max(matchAllTime.Wins - matchSum.Sum(x => x.Wins), 0),
                    PlayerId = playerId,
                    GameweekId = gameweekId,
                };

                var teamPlayStatistics = new TeamPlayStatistics
                {
                    AccurateLongBalls = (short) Math.Max(teamPlayAllTime.AccurateLongBalls - teamPlaySum.Sum(x => x.AccurateLongBalls), 0),
                    BigChancesCreated = (short) Math.Max(teamPlayAllTime.BigChancesCreated - teamPlaySum.Sum(x => x.BigChancesCreated), 0),
                    ThroughBalls = (short) Math.Max(teamPlayAllTime.ThroughBalls - teamPlaySum.Sum(x => x.ThroughBalls), 0),
                    Assists = (short) Math.Max(teamPlayAllTime.Assists - teamPlaySum.Sum(x => x.Assists), 0),
                    Crosses = (short) Math.Max(teamPlayAllTime.Crosses - teamPlaySum.Sum(x => x.Crosses), 0),
                    Passes = (short) Math.Max(teamPlayAllTime.Passes - teamPlaySum.Sum(x => x.Passes), 0),
                    PlayerId = playerId,
                    GameweekId = gameweekId,
                };

                var attackStatistics = new AttackStatistics
                {
                    BigChancesMissed = (short) Math.Max(attackAllTime.BigChancesMissed - attackSum.Sum(x => x.BigChancesMissed), 0),
                    PenaltiesScored = (short) Math.Max(attackAllTime.PenaltiesScored - attackSum.Sum(x => x.PenaltiesScored), 0),
                    FreeKicksScored = (short) Math.Max(attackAllTime.FreeKicksScored - attackSum.Sum(x => x.FreeKicksScored), 0),
                    ShotsOnTarget = (short) Math.Max(attackAllTime.ShotsOnTarget - attackSum.Sum(x => x.ShotsOnTarget), 0),
                    HitWoodwork = (short) Math.Max(attackAllTime.HitWoodwork - attackSum.Sum(x => x.HitWoodwork), 0),
                    Goals = (short) Math.Max(attackAllTime.Goals - attackSum.Sum(x => x.Goals), 0),
                    Shots = (short) Math.Max(attackAllTime.Shots - attackSum.Sum(x => x.Shots), 0),
                    PlayerId = playerId,
                    GameweekId = gameweekId,
                };

                var disciplineStatistics = new DisciplineStatistics
                {
                    YellowCards = (short) Math.Max(disciplineAllTime.YellowCards - disciplineSum.Sum(x => x.YellowCards), 0),
                    RedCards = (short) Math.Max(disciplineAllTime.RedCards - disciplineSum.Sum(x => x.RedCards), 0),
                    Offsides = (short) Math.Max(disciplineAllTime.Offsides - disciplineSum.Sum(x => x.Offsides), 0),
                    Fouls = (short) Math.Max(disciplineAllTime.Fouls - disciplineSum.Sum(x => x.Fouls), 0),
                    PlayerId = playerId,
                    GameweekId = gameweekId,
                };

                var goalkeepingStatistics = new GoalkeepingStatistics
                {
                    SweeperClearances = (short) Math.Max(goalkeepingAllTime.SweeperClearances - goalkeepingSum.Sum(x => x.SweeperClearances), 0),
                    PenaltiesSaved = (short) Math.Max(goalkeepingAllTime.PenaltiesSaved - goalkeepingSum.Sum(x => x.PenaltiesSaved), 0),
                    HighClaims = (short) Math.Max(goalkeepingAllTime.HighClaims - goalkeepingSum.Sum(x => x.HighClaims), 0),
                    GoalKicks = (short) Math.Max(goalkeepingAllTime.GoalKicks - goalkeepingSum.Sum(x => x.GoalKicks), 0),
                    Punches = (short) Math.Max(goalkeepingAllTime.Punches - goalkeepingSum.Sum(x => x.Punches), 0),
                    Catches = (short )Math.Max(goalkeepingAllTime.Catches - goalkeepingSum.Sum(x => x.Catches), 0),
                    Saves = (short) Math.Max(goalkeepingAllTime.Saves - goalkeepingSum.Sum(x => x.Saves), 0),
                    PlayerId = playerId,
                    GameweekId = gameweekId,
                };

                statisticsCollection.Add(defenceStatistics);
                statisticsCollection.Add(matchStatistics);
                statisticsCollection.Add(teamPlayStatistics);
                statisticsCollection.Add(attackStatistics);
                statisticsCollection.Add(disciplineStatistics);
                statisticsCollection.Add(goalkeepingStatistics);
            }

            return statisticsCollection;
        }
    }
}
    