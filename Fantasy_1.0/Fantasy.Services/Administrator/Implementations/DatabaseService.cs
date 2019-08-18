using System;
using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Services.Administrator.Models.Db;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.FootballPlayers;
using Fantasy.Data.Models.Statistics;

namespace Fantasy.Services.Administrator.Implementations
{
    public class DatabaseService : IDatabaseService
    {
        private const int AllTimeGameweekId = 2;

        private readonly FantasyDbContext db;

        public DatabaseService(FantasyDbContext db)
        {
            this.db = db;
        }

        public void ExportFootballPlayers()
        {
            return;
            var players = this.db.FootballPlayers.To<FootballPlayerJsonModel>().ToList();
            File.WriteAllText("wwwroot/JsonFiles/footballPlayers.json", JsonConvert.SerializeObject(players));
        }

        public void ExportFootballPlayerInfos()
        {
            return;
            var infos = this.db.FootballPlayerInfos.To<FootballPlayerInfoJsonModel>().ToList();
            File.WriteAllText("wwwroot/JsonFiles/footballPlayerInfos.json", JsonConvert.SerializeObject(infos));
        }

        public void ExportStatistics(Gameweek gameweek)
        {
            return;

            var attackStatistics = this.db.AttackStatistics.Where(s => s.GameweekId == gameweek.Id).ToList();
            var matchStatistics = this.db.MatchStatistics.Where(s => s.GameweekId == gameweek.Id).ToList();
            var defenceStatistics = this.db.DefenceStatistics.Where(s => s.GameweekId == gameweek.Id).ToList();
            var teamPlayStatistics = this.db.TeamPlayStatistics.Where(s => s.GameweekId == gameweek.Id).ToList();
            var disciplineStatistics = this.db.DisciplineStatistics.Where(s => s.GameweekId == gameweek.Id).ToList();
            var goalkeepingStatistics = this.db.GoalkeepingStatistics.Where(s => s.GameweekId == gameweek.Id).ToList();

            File.WriteAllText($"wwwroot/JsonFiles/GW{gameweek.Number}/attackStatGW{gameweek.Number}.json",
                JsonConvert.SerializeObject(attackStatistics));
            File.WriteAllText($"wwwroot/JsonFiles/GW{gameweek.Number}/matchStatGW{gameweek.Number}.json",
                JsonConvert.SerializeObject(matchStatistics));
            File.WriteAllText($"wwwroot/JsonFiles/GW{gameweek.Number}/defenceStatGW{gameweek.Number}.json",
                JsonConvert.SerializeObject(defenceStatistics));
            File.WriteAllText($"wwwroot/JsonFiles/GW{gameweek.Number}/teamPlayStatGW{gameweek.Number}.json",
                JsonConvert.SerializeObject(teamPlayStatistics));
            File.WriteAllText($"wwwroot/JsonFiles/GW{gameweek.Number}/disciplineStatGW{gameweek.Number}.json",
                JsonConvert.SerializeObject(disciplineStatistics));
            File.WriteAllText($"wwwroot/JsonFiles/GW{gameweek.Number}/goalkeepingStatGW{gameweek.Number}.json",
                JsonConvert.SerializeObject(goalkeepingStatistics));
        }

        public string SeedPlayers()
        {
            var playersJson = File.ReadAllText("wwwroot/JsonFiles/footballPlayers.json");
            var playerInfosJson = File.ReadAllText("wwwroot/JsonFiles/footballPlayerInfos.json");

            var players = JsonConvert.DeserializeObject<List<FootballPlayerJsonModel>>(playersJson);

            if (this.db.FootballPlayers.Any())
            {
                return "The players have been seeded already!";
            }

            var allPlayers = players.To<FootballPlayer>().ToList();
            var result = 0;

            db.AddRange(allPlayers);
            db.Database.OpenConnection();

            try
            {
                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.FootballPlayers ON");
                result += db.SaveChanges();
                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.FootballPlayers OFF");
            }
            finally
            {
                db.Database.CloseConnection();
            }

            var playersInfo = JsonConvert.DeserializeObject<List<FootballPlayerInfoJsonModel>>(playerInfosJson);
            var infos = playersInfo.To<FootballPlayerInfo>().ToList();

            this.db.AddRange(infos);
            this.db.SaveChanges();

            return $"{result} players have been seeded!";
        }
        
        public string ImportStatistics(int gameweekNumber)
        {
            //return null;

            if (this.db.MatchStatistics.Any(x => x.Gameweek.Number == gameweekNumber))
            {
                return "Statistics already seeded!";
            }

            var statistics = new List<BaseStatistics>();

            try
            {
                statistics.AddRange(JsonConvert.DeserializeObject<List<AttackStatistics>>
                    (File.ReadAllText($"wwwroot/JsonFiles/GW{gameweekNumber}/attackStatGW{gameweekNumber}.json")));
                statistics.AddRange(JsonConvert.DeserializeObject<List<MatchStatistics>>
                    (File.ReadAllText($"wwwroot/JsonFiles/GW{gameweekNumber}/matchStatGW{gameweekNumber}.json")));
                statistics.AddRange(JsonConvert.DeserializeObject<List<DefenceStatistics>>
                    (File.ReadAllText($"wwwroot/JsonFiles/GW{gameweekNumber}/defenceStatGW{gameweekNumber}.json")));
                statistics.AddRange(JsonConvert.DeserializeObject<List<TeamPlayStatistics>>
                    (File.ReadAllText($"wwwroot/JsonFiles/GW{gameweekNumber}/teamPlayStatGW{gameweekNumber}.json")));
                statistics.AddRange(JsonConvert.DeserializeObject<List<DisciplineStatistics>>
                    (File.ReadAllText($"wwwroot/JsonFiles/GW{gameweekNumber}/disciplineStatGW{gameweekNumber}.json")));
                statistics.AddRange(JsonConvert.DeserializeObject<List<GoalkeepingStatistics>>
                    (File.ReadAllText($"wwwroot/JsonFiles/GW{gameweekNumber}/goalkeepingStatGW{gameweekNumber}.json")));
            }
            catch (Exception)
            {
                return "No Json files found!";
            }



            this.db.AddRange(statistics);
            var result = this.db.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return result.ToString();
        }
             

        //todo refactor
        public string SeedStatistics(int gameweekId)
        {
            if (this.db.MatchStatistics.Any(ms => ms.GameweekId == gameweekId))
            {
                return null;
            }

            //todo
            //export first!!!


            this.db.RemoveRange(db.DefenceStatistics.Where(x => x.GameweekId == AllTimeGameweekId));
            this.db.RemoveRange(db.TeamPlayStatistics.Where(x => x.GameweekId == AllTimeGameweekId));
            this.db.RemoveRange(db.GoalkeepingStatistics.Where(x => x.GameweekId == AllTimeGameweekId));
            this.db.RemoveRange(db.MatchStatistics.Where(x => x.GameweekId == AllTimeGameweekId));
            this.db.RemoveRange(db.DisciplineStatistics.Where(x => x.GameweekId == AllTimeGameweekId));
            this.db.RemoveRange(db.AttackStatistics.Where(x => x.GameweekId == AllTimeGameweekId));

            var result = "Records removed: " +  this.db.SaveChanges();


            //todo opravi si bataka
            var dbFootballPlayerIds = this.db.FootballPlayers
                .Where(x => x.FootballClub.Id == 8)
                .Select(p => p.Id)
                .ToList();

            result += " / New all time records added: " + GetNewAllTimePlayersStatistics(dbFootballPlayerIds);

            result += " / New gameweek records added: " + CreateNewGameweekStatistics(dbFootballPlayerIds, gameweekId);

            return result;
        }
        

        private int GetNewAllTimePlayersStatistics(List<int> dbFootballPlayerIds)
        {
            var statisticsPropertyRegex = new Regex("<span class=\"stat\">([A-Za-z\\ ]+)   <span.+\\s+([0-9\\.\\,]+)");
            var customStatisticsPropertyRegex = new Regex("<span class=\"stat\">(Successful 50/50s)   <span.+\\s+([0-9\\.\\,]+)");

            var newGameweekStatisticsCollection = new List<BaseStatistics>();

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
                        playerStatistics.GameweekId = AllTimeGameweekId;
                        playerStatistics.PlayerId = playerId;

                        foreach (var kvp in properties)
                        {
                            playerStatistics
                                .GetType()
                                .GetProperty(kvp.Key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                                ?.SetValue(playerStatistics, short.Parse(kvp.Value));
                        }
                    }

                    newGameweekStatisticsCollection.AddRange(playerStatisticsCollection);
                }

                response.Close();
            }

            this.db.AddRange(newGameweekStatisticsCollection);
            return this.db.SaveChanges();
        }


        //todo refactor
        private int CreateNewGameweekStatistics(List<int> dbFootballPlayerIds, int gameweekId)
        {
            var statisticsCollection = new List<BaseStatistics>();

            foreach (var playerId in dbFootballPlayerIds)
            {
                var defenceAllTime = this.db.DefenceStatistics.First(x => x.GameweekId == 2 && x.PlayerId == playerId);
                var defenceSum = this.db.DefenceStatistics.Where(x => x.GameweekId != 2 && x.PlayerId == playerId).ToList();

                var matchAllTime = this.db.MatchStatistics.First(x => x.GameweekId == 2 && x.PlayerId == playerId);
                var matchSum = this.db.MatchStatistics.Where(x => x.GameweekId != 2 && x.PlayerId == playerId).ToList();

                var teamPlayAllTime = this.db.TeamPlayStatistics.First(x => x.GameweekId == 2 && x.PlayerId == playerId);
                var teamPlaySum = this.db.TeamPlayStatistics.Where(x => x.GameweekId != 2 && x.PlayerId == playerId).ToList();

                var attackAllTime = this.db.AttackStatistics.First(x => x.GameweekId == 2 && x.PlayerId == playerId);
                var attackSum = this.db.AttackStatistics.Where(x => x.GameweekId != 2 && x.PlayerId == playerId).ToList();

                var disciplineAllTime = this.db.DisciplineStatistics.First(x => x.GameweekId == 2 && x.PlayerId == playerId);
                var disciplineSum = this.db.DisciplineStatistics.Where(x => x.GameweekId != 2 && x.PlayerId == playerId).ToList();

                var goalkeepingAllTime = this.db.GoalkeepingStatistics.First(x => x.GameweekId == 2 && x.PlayerId == playerId);
                var goalkeepingSum = this.db.GoalkeepingStatistics.Where(x => x.GameweekId != 2 && x.PlayerId == playerId).ToList();

                var defenceStatistics = new DefenceStatistics
                {
                    SuccessfulFiftyFifties = (short) (defenceAllTime.SuccessfulFiftyFifties - defenceSum.Sum(x => x.SuccessfulFiftyFifties)),
                    ErrorsLeadingToGoal = (short) (defenceAllTime.ErrorsLeadingToGoal - defenceSum.Sum(x => x.ErrorsLeadingToGoal)),
                    AerialBattlesLost = (short) (defenceAllTime.AerialBattlesLost - defenceSum.Sum(x => x.AerialBattlesLost)),
                    AerialBattlesWon = (short) (defenceAllTime.AerialBattlesWon - defenceSum.Sum(x => x.AerialBattlesWon)),
                    HeadedClearance = (short) (defenceAllTime.HeadedClearance - defenceSum.Sum(x => x.HeadedClearance)),
                    LastManTackles = (short) (defenceAllTime.LastManTackles - defenceSum.Sum(x => x.LastManTackles)),
                    Interceptions = (short) (defenceAllTime.Interceptions - defenceSum.Sum(x => x.Interceptions)),
                    GoalsConceded = (short) (defenceAllTime.GoalsConceded - defenceSum.Sum(x => x.GoalsConceded)),
                    BlockedShots = (short) (defenceAllTime.BlockedShots - defenceSum.Sum(x => x.BlockedShots)),
                    CleanSheets = (short) (defenceAllTime.CleanSheets - defenceSum.Sum(x => x.CleanSheets)),
                    Clearances = (short) (defenceAllTime.Clearances - defenceSum.Sum(x => x.Clearances)),
                    Recoveries = (short) (defenceAllTime.Recoveries - defenceSum.Sum(x => x.Recoveries)),
                    DuelsLost = (short) (defenceAllTime.DuelsLost - defenceSum.Sum(x => x.DuelsLost)),
                    DuelsWon = (short) (defenceAllTime.DuelsWon - defenceSum.Sum(x => x.DuelsWon)),
                    OwnGoals = (short) (defenceAllTime.OwnGoals - defenceSum.Sum(x => x.OwnGoals)),
                    Tackles = (short) (defenceAllTime.Tackles - defenceSum.Sum(x => x.Tackles)),
                    PlayerId = playerId,
                    GameweekId = gameweekId,
                };

                var matchStatistics = new MatchStatistics
                {
                    Appearances = (short) (matchAllTime.Appearances - matchSum.Sum(x => x.Appearances)),
                    Losses = (short) (matchAllTime.Losses - matchSum.Sum(x => x.Losses)),
                    Wins = (short) (matchAllTime.Wins - matchSum.Sum(x => x.Wins)),
                    PlayerId = playerId,
                    GameweekId = gameweekId,
                };

                var teamPlayStatistics = new TeamPlayStatistics
                {
                    AccurateLongBalls = (short) (teamPlayAllTime.AccurateLongBalls - teamPlaySum.Sum(x => x.AccurateLongBalls)),
                    BigChancesCreated = (short) (teamPlayAllTime.BigChancesCreated - teamPlaySum.Sum(x => x.BigChancesCreated)),
                    ThroughBalls = (short) (teamPlayAllTime.ThroughBalls - teamPlaySum.Sum(x => x.ThroughBalls)),
                    Assists = (short) (teamPlayAllTime.Assists - teamPlaySum.Sum(x => x.Assists)),
                    Crosses = (short)(teamPlayAllTime.Crosses - teamPlaySum.Sum(x => x.Crosses)),
                    Passes = (short) (teamPlayAllTime.Passes - teamPlaySum.Sum(x => x.Passes)),
                    PlayerId = playerId,
                    GameweekId = gameweekId,
                };

                var attackStatistics = new AttackStatistics
                {
                    BigChancesMissed = (short) (attackAllTime.BigChancesMissed - attackSum.Sum(x => x.BigChancesMissed)),
                    PenaltiesScored = (short) (attackAllTime.PenaltiesScored - attackSum.Sum(x => x.PenaltiesScored)),
                    FreeKicksScored = (short) (attackAllTime.FreeKicksScored - attackSum.Sum(x => x.FreeKicksScored)),
                    ShotsOnTarget = (short) (attackAllTime.ShotsOnTarget - attackSum.Sum(x => x.ShotsOnTarget)),
                    HitWoodwork = (short) (attackAllTime.HitWoodwork - attackSum.Sum(x => x.HitWoodwork)),
                    Goals = (short) (attackAllTime.Goals - attackSum.Sum(x => x.Goals)),
                    Shots = (short) (attackAllTime.Shots - attackSum.Sum(x => x.Shots)),
                    PlayerId = playerId,
                    GameweekId = gameweekId,
                };

                var disciplineStatistics = new DisciplineStatistics
                {
                    YellowCards = (short) (disciplineAllTime.YellowCards - disciplineSum.Sum(x => x.YellowCards)),
                    RedCards = (short) (disciplineAllTime.RedCards - disciplineSum.Sum(x => x.RedCards)),
                    Offsides = (short) (disciplineAllTime.Offsides - disciplineSum.Sum(x => x.Offsides)),
                    Fouls = (short) (disciplineAllTime.Fouls - disciplineSum.Sum(x => x.Fouls)),
                    PlayerId = playerId,
                    GameweekId = gameweekId,
                };

                var goalkeepingStatistics = new GoalkeepingStatistics
                {
                    SweeperClearances = (short) (goalkeepingAllTime.SweeperClearances - goalkeepingSum.Sum(x => x.SweeperClearances)),
                    PenaltiesSaved = (short) (goalkeepingAllTime.PenaltiesSaved - goalkeepingSum.Sum(x => x.PenaltiesSaved)),
                    HighClaims = (short) (goalkeepingAllTime.HighClaims - goalkeepingSum.Sum(x => x.HighClaims)),
                    GoalKicks = (short) (goalkeepingAllTime.GoalKicks - goalkeepingSum.Sum(x => x.GoalKicks)),
                    Punches = (short) (goalkeepingAllTime.Punches - goalkeepingSum.Sum(x => x.Punches)),
                    Catches = (short) (goalkeepingAllTime.Catches - goalkeepingSum.Sum(x => x.Catches)),
                    Saves = (short) (goalkeepingAllTime.Saves - goalkeepingSum.Sum(x => x.Saves)),
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

            this.db.AddRange(statisticsCollection);

            return this.db.SaveChanges();
        }
    }
}
    