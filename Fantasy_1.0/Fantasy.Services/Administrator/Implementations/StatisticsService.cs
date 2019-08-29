using Fantasy.Common;
using Fantasy.Common.Attributes;
using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models;
using Fantasy.Services.Administrator.Models;
using Fantasy.Services.Models;
using Fantasy.Services.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            var player = await this.db.FindAsync<FootballPlayer>(playerId);
            var gameweek = await this.db.FindAsync<Gameweek>(gameweekId);
            //todo validate
            return this.db.GameweekStatistics.Where(x => x.Gameweek == gameweek && x.FootballPlayer == player)
                .To<TModel>().FirstOrDefault();
        }
        //todo refactor 
        public async Task<int> EditPlayerStatisticsAsync(FootballPlayerStatisticsFormModel model)
        {

            var gameweekStat = await this.db.FindAsync<GameweekStatistics>(model.PlayerId, model.GameweekId);

            if (gameweekStat == null)
            {
                return 0;
            }

            {
                gameweekStat.Appearances = model.Appearances;
                gameweekStat.Losses = model.Losses;
                gameweekStat.Wins = model.Wins;
                gameweekStat.BigChancesMissed = model.BigChancesMissed;
                gameweekStat.FreeKicksScored = model.FreeKicksScored;
                gameweekStat.Goals = model.Goals;
                gameweekStat.HitWoodwork = model.HitWoodwork;
                gameweekStat.PenaltiesScored = model.PenaltiesScored;
                gameweekStat.Shots = model.Shots;
                gameweekStat.ShotsOnTarget = model.ShotsOnTarget;
                gameweekStat.AerialBattlesLost = model.AerialBattlesLost;
                gameweekStat.AerialBattlesWon = model.AerialBattlesWon;
                gameweekStat.BlockedShots = model.BlockedShots;
                gameweekStat.CleanSheets = model.CleanSheets;
                gameweekStat.Clearances = model.Clearances;
                gameweekStat.DuelsLost = model.DuelsLost;
                gameweekStat.DuelsWon = model.DuelsWon;
                gameweekStat.ErrorsLeadingToGoal = model.ErrorsLeadingToGoal;
                gameweekStat.GoalsConceded = model.GoalsConceded;
                gameweekStat.HeadedClearance = model.HeadedClearance;
                gameweekStat.LastManTackles = model.LastManTackles;
                gameweekStat.OwnGoals = model.OwnGoals;
                gameweekStat.Recoveries = model.Recoveries;
                gameweekStat.Tackles = model.Tackles;
                gameweekStat.SuccessfulFiftyFifties = model.SuccessfulFiftyFifties;
                gameweekStat.Interceptions = model.Interceptions;
                gameweekStat.AccurateLongBalls = model.AccurateLongBalls;
                gameweekStat.Assists = model.Assists;
                gameweekStat.BigChancesCreated = model.BigChancesCreated;
                gameweekStat.Crosses = model.Crosses;
                gameweekStat.Passes = model.Passes;
                gameweekStat.ThroughBalls = model.ThroughBalls;
                gameweekStat.Fouls = model.Fouls;
                gameweekStat.Offsides = model.Fouls;
                gameweekStat.RedCards = model.RedCards;
                gameweekStat.YellowCards = model.YellowCards;
                gameweekStat.Catches = model.Catches;
                gameweekStat.GoalKicks = model.GoalKicks;
                gameweekStat.HighClaims = model.HighClaims;
                gameweekStat.PenaltiesSaved = model.PenaltiesSaved;
                gameweekStat.Saves = model.Saves;
                gameweekStat.SweeperClearances = model.SweeperClearances;
                gameweekStat.Punches = model.Punches;
            }
            

            var result = await this.db.SaveChangesAsync();

            return result;
        }

        public async Task<int> UpdateFootballPlayersPointsAsync(int gameweekId)
        {
            var players = await this.db.FootballPlayers
                .Include(p => p.Position)
                .Include(p => p.GameweekPoints)
                //.Where(x => x.Info.Name.Contains("Mohamed Salah") || x.Info.Name.Contains("Harry Kane"))
                .ToListAsync();

            foreach (var player in players)
            {
                IHaveMatchStatistics statistics;
                var points = 0;

                switch (player.Position.Name)
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
                    default: return -1;
                }

                if (statistics == null)
                {
                    return -1;
                }

                //calculate each football player points
                statistics
                    .GetType()
                    .GetProperties()
                    .Where(p => p.PropertyType == typeof(short))
                    .ToList()
                    .ForEach(p =>
                    {
                        points += (short) p.GetValue(statistics) * p.GetCustomAttribute<PointsAttribute>().Units;
                    });

                player.GameweekPoints.First(x => x.GameweekId == gameweekId).Points = points;
            }

            var result = this.db.SaveChanges();
            Console.WriteLine(result);


            var users = this.db.Users
                .Where(u => u.Squad.Count != 0)
                .Include(u => u.Squad)
                .ThenInclude(fp => fp.GameweekStatuses)
                .Include(u => u.GameweekScoreses)
                .ToList();
            
            Console.WriteLine();


            //update each user score
            foreach (var user in users)
            {
                var score = user.Squad
                    .Where(x => x.FantasyUser == user &&
                                x.GameweekStatuses.First(y => y.GameweekId == gameweekId).IsBenched == false)
                    .Sum(x => x.FootballPlayer.GameweekPoints.First(y => y.GameweekId == gameweekId).Points);


                   Console.WriteLine(score);
                user.GameweekScoreses.First(x => x.GameweekId == gameweekId).Score = score;

                Console.WriteLine();
            }

            result += await this.db.SaveChangesAsync();

            return result;
        }


        //todo refactor
        public string Seed(int gameweekId)
        {
            if (this.db.GameweekStatistics.Any(ms => ms.GameweekId == gameweekId))
            {
                return null;
            }


            //todo
            //export first!!!
            var result = string.Empty;
            var statisticsCollection = new List<GameweekStatistics>();

            //todo update group of players only !!!
            var dbFootballPlayerIds = this.db.FootballPlayers
                // .Where(x => x.FootballClub.Id == 10)
                .Select(p => p.Id)
                .ToList();

            statisticsCollection = GetNewAllTimeStatisticsCollection(dbFootballPlayerIds);

            this.db.RemoveRange(db.GameweekStatistics.Where(x => x.GameweekId == AllTimeStatisticsGameweekId));

            result = "Records removed: " + this.db.SaveChanges();

            this.db.AddRange(statisticsCollection);

            result += " / New all time records added: " + this.db.SaveChanges();

            statisticsCollection = CreateNewGameweekStatistics(dbFootballPlayerIds, gameweekId);

            this.db.AddRange(statisticsCollection);

            result += " / New gameweek records added: " + this.db.SaveChanges();

            return result;
        }

        private List<GameweekStatistics> GetNewAllTimeStatisticsCollection(List<int> dbFootballPlayerIds)
        {
            var statisticsPropertyRegex = new Regex("<span class=\"stat\">([A-Za-z\\ ]+)   <span.+\\s+([0-9\\.\\,]+)");
            var customStatisticsPropertyRegex = new Regex("<span class=\"stat\">(Successful 50/50s)   <span.+\\s+([0-9\\.\\,]+)");

            var statisticsCollection = new List<GameweekStatistics>();

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

                   
                    var playerStatistics = new GameweekStatistics();
                    playerStatistics.PlayerId = playerId;
                    playerStatistics.GameweekId = AllTimeStatisticsGameweekId;

                    foreach (var kvp in properties)
                    {
                        playerStatistics
                            .GetType()
                            .GetProperty(kvp.Key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                            ?.SetValue(playerStatistics, short.Parse(kvp.Value));
                    }

                    statisticsCollection.Add(playerStatistics);
                }

                response.Close();
            }

            return statisticsCollection;
        }

        //todo refactor
        private List<GameweekStatistics> CreateNewGameweekStatistics(List<int> dbFootballPlayerIds, int gameweekId)
        {
            var statisticsCollection = new List<GameweekStatistics>();

            foreach (var playerId in dbFootballPlayerIds)
            {
                var allTimeStatistics = this.db.GameweekStatistics.First(x => x.GameweekId == AllTimeStatisticsGameweekId && x.PlayerId == playerId);
                var sumOfRestStatistics = this.db.GameweekStatistics.Where(x => x.GameweekId != AllTimeStatisticsGameweekId && x.PlayerId == playerId).ToList();

                var statistics = new GameweekStatistics
                {
                    SuccessfulFiftyFifties = (short)Math.Max(allTimeStatistics.SuccessfulFiftyFifties - sumOfRestStatistics.Sum(x => x.SuccessfulFiftyFifties), 0),
                    ErrorsLeadingToGoal = (short)Math.Max(allTimeStatistics.ErrorsLeadingToGoal - sumOfRestStatistics.Sum(x => x.ErrorsLeadingToGoal), 0),
                    SweeperClearances = (short)Math.Max(allTimeStatistics.SweeperClearances - sumOfRestStatistics.Sum(x => x.SweeperClearances), 0),
                    AccurateLongBalls = (short)Math.Max(allTimeStatistics.AccurateLongBalls - sumOfRestStatistics.Sum(x => x.AccurateLongBalls), 0),
                    BigChancesCreated = (short)Math.Max(allTimeStatistics.BigChancesCreated - sumOfRestStatistics.Sum(x => x.BigChancesCreated), 0),
                    AerialBattlesLost = (short)Math.Max(allTimeStatistics.AerialBattlesLost - sumOfRestStatistics.Sum(x => x.AerialBattlesLost), 0),
                    BigChancesMissed = (short)Math.Max(allTimeStatistics.BigChancesMissed - sumOfRestStatistics.Sum(x => x.BigChancesMissed), 0),
                    AerialBattlesWon = (short)Math.Max(allTimeStatistics.AerialBattlesWon - sumOfRestStatistics.Sum(x => x.AerialBattlesWon), 0),
                    PenaltiesScored = (short)Math.Max(allTimeStatistics.PenaltiesScored - sumOfRestStatistics.Sum(x => x.PenaltiesScored), 0),
                    FreeKicksScored = (short)Math.Max(allTimeStatistics.FreeKicksScored - sumOfRestStatistics.Sum(x => x.FreeKicksScored), 0),
                    HeadedClearance = (short)Math.Max(allTimeStatistics.HeadedClearance - sumOfRestStatistics.Sum(x => x.HeadedClearance), 0),
                    PenaltiesSaved = (short)Math.Max(allTimeStatistics.PenaltiesSaved - sumOfRestStatistics.Sum(x => x.PenaltiesSaved), 0),
                    LastManTackles = (short)Math.Max(allTimeStatistics.LastManTackles - sumOfRestStatistics.Sum(x => x.LastManTackles), 0),
                    ShotsOnTarget = (short)Math.Max(allTimeStatistics.ShotsOnTarget - sumOfRestStatistics.Sum(x => x.ShotsOnTarget), 0),
                    Interceptions = (short)Math.Max(allTimeStatistics.Interceptions - sumOfRestStatistics.Sum(x => x.Interceptions), 0),
                    GoalsConceded = (short)Math.Max(allTimeStatistics.GoalsConceded - sumOfRestStatistics.Sum(x => x.GoalsConceded), 0),
                    ThroughBalls = (short)Math.Max(allTimeStatistics.ThroughBalls - sumOfRestStatistics.Sum(x => x.ThroughBalls), 0),
                    BlockedShots = (short)Math.Max(allTimeStatistics.BlockedShots - sumOfRestStatistics.Sum(x => x.BlockedShots), 0),
                    HitWoodwork = (short)Math.Max(allTimeStatistics.HitWoodwork - sumOfRestStatistics.Sum(x => x.HitWoodwork), 0),
                    YellowCards = (short)Math.Max(allTimeStatistics.YellowCards - sumOfRestStatistics.Sum(x => x.YellowCards), 0),
                    Appearances = (short)Math.Max(allTimeStatistics.Appearances - sumOfRestStatistics.Sum(x => x.Appearances), 0),
                    CleanSheets = (short)Math.Max(allTimeStatistics.CleanSheets - sumOfRestStatistics.Sum(x => x.CleanSheets), 0),
                    HighClaims = (short)Math.Max(allTimeStatistics.HighClaims - sumOfRestStatistics.Sum(x => x.HighClaims), 0),
                    Clearances = (short)Math.Max(allTimeStatistics.Clearances - sumOfRestStatistics.Sum(x => x.Clearances), 0),
                    Recoveries = (short)Math.Max(allTimeStatistics.Recoveries - sumOfRestStatistics.Sum(x => x.Recoveries), 0),
                    DuelsLost = (short)Math.Max(allTimeStatistics.DuelsLost - sumOfRestStatistics.Sum(x => x.DuelsLost), 0),
                    GoalKicks = (short)Math.Max(allTimeStatistics.GoalKicks - sumOfRestStatistics.Sum(x => x.GoalKicks), 0),
                    RedCards = (short)Math.Max(allTimeStatistics.RedCards - sumOfRestStatistics.Sum(x => x.RedCards), 0),
                    Offsides = (short)Math.Max(allTimeStatistics.Offsides - sumOfRestStatistics.Sum(x => x.Offsides), 0),
                    DuelsWon = (short)Math.Max(allTimeStatistics.DuelsWon - sumOfRestStatistics.Sum(x => x.DuelsWon), 0),
                    OwnGoals = (short)Math.Max(allTimeStatistics.OwnGoals - sumOfRestStatistics.Sum(x => x.OwnGoals), 0),
                    Tackles = (short)Math.Max(allTimeStatistics.Tackles - sumOfRestStatistics.Sum(x => x.Tackles), 0),
                    Assists = (short)Math.Max(allTimeStatistics.Assists - sumOfRestStatistics.Sum(x => x.Assists), 0),
                    Crosses = (short)Math.Max(allTimeStatistics.Crosses - sumOfRestStatistics.Sum(x => x.Crosses), 0),
                    Punches = (short)Math.Max(allTimeStatistics.Punches - sumOfRestStatistics.Sum(x => x.Punches), 0),
                    Catches = (short)Math.Max(allTimeStatistics.Catches - sumOfRestStatistics.Sum(x => x.Catches), 0),
                    Losses = (short)Math.Max(allTimeStatistics.Losses - sumOfRestStatistics.Sum(x => x.Losses), 0),
                    Passes = (short)Math.Max(allTimeStatistics.Passes - sumOfRestStatistics.Sum(x => x.Passes), 0),
                    Goals = (short)Math.Max(allTimeStatistics.Goals - sumOfRestStatistics.Sum(x => x.Goals), 0),
                    Shots = (short)Math.Max(allTimeStatistics.Shots - sumOfRestStatistics.Sum(x => x.Shots), 0),
                    Fouls = (short)Math.Max(allTimeStatistics.Fouls - sumOfRestStatistics.Sum(x => x.Fouls), 0),
                    Saves = (short)Math.Max(allTimeStatistics.Saves - sumOfRestStatistics.Sum(x => x.Saves), 0),
                    Wins = (short)Math.Max(allTimeStatistics.Wins - sumOfRestStatistics.Sum(x => x.Wins), 0),
                    PlayerId = playerId,
                    GameweekId = gameweekId,
                };

                statisticsCollection.Add(statistics);
            }

            return statisticsCollection;
        }
    }
}
    