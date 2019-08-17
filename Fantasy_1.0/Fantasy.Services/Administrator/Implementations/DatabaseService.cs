using System;
using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Services.Administrator.Models.Db;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
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
        private const int StatisticsTypeCount = 6;

        private readonly FantasyDbContext db;

        public DatabaseService(FantasyDbContext db)
        {
            this.db = db;
        }

        public void CreateJsonFilePlayers()
        {
            return;
            var players = this.db.FootballPlayers.To<FootballPlayerJsonModel>().ToList();
            File.WriteAllText("wwwroot/JsonFiles/footballPlayers.json", JsonConvert.SerializeObject(players));
        }

        public void CreateJsonFilePlayerInfos()
        {
            return;
            var infos = this.db.FootballPlayerInfos.To<FootballPlayerInfoJsonModel>().ToList();
            File.WriteAllText("wwwroot/JsonFiles/footballPlayerInfos.json", JsonConvert.SerializeObject(infos));
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
        public void CreateJsonFilesStatistics(Gameweek gameweek)
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


        //todo complete
        public string SeedStatistics()
        {
            //if (this.db.AttackStatistics.Any())
            //{
            //    return "Don't!";
            //}
            

            var dbFootballPlayerIds = this.db.FootballPlayers
                .Select(p => p.Id)
                .ToList();

            //GetNewAllTimePlayersStatistics(dbFootballPlayerIds);


            //return result.ToString();
            return null;

        }

        public string SeedStatisticsFromJsonFiles(int gameweekNumber)
        {
            var stat = new List<BaseStatistics>();

            stat.AddRange(JsonConvert.DeserializeObject<List<AttackStatistics>>
                (File.ReadAllText($"wwwroot/JsonFiles/GW{gameweekNumber}/attackStatGW{gameweekNumber}.json")));
            stat.AddRange(JsonConvert.DeserializeObject<List<MatchStatistics>>
                (File.ReadAllText($"wwwroot/JsonFiles/GW{gameweekNumber}/matchStatGW{gameweekNumber}.json")));
            stat.AddRange(JsonConvert.DeserializeObject<List<DefenceStatistics>>
                (File.ReadAllText($"wwwroot/JsonFiles/GW{gameweekNumber}/defenceStatGW{gameweekNumber}.json")));
            stat.AddRange(JsonConvert.DeserializeObject<List<TeamPlayStatistics>>
                (File.ReadAllText($"wwwroot/JsonFiles/GW{gameweekNumber}/teamPlayStatGW{gameweekNumber}.json")));
            stat.AddRange(JsonConvert.DeserializeObject<List<DisciplineStatistics>>
                (File.ReadAllText($"wwwroot/JsonFiles/GW{gameweekNumber}/disciplineStatGW{gameweekNumber}.json")));
            stat.AddRange(JsonConvert.DeserializeObject<List<GoalkeepingStatistics>>
                (File.ReadAllText($"wwwroot/JsonFiles/GW{gameweekNumber}/goalkeepingStatGW{gameweekNumber}.json")));

            this.db.AddRange(stat);

            return this.db.SaveChanges().ToString();
        }
        

        private void GetNewAllTimePlayersStatistics(List<int> dbFootballPlayerIds)
        {
            var statisticsPropertyRegex = new Regex("<span class=\"stat\">([A-Za-z\\ ]+)   <span.+\\s+([0-9\\.\\,]+)");
            var customStatisticsPropertyRegex = new Regex("<span class=\"stat\">(Successful 50/50s)   <span.+\\s+([0-9\\.\\,]+)");

            var newGameweekStatisticsCollection = new List<BaseStatistics>();

            foreach (var playerId in dbFootballPlayerIds)
            {
                Console.WriteLine(playerId);
                var properties = new Dictionary<string, string>();

                //todo must be gameweek0!!!!
                var gameweekId = 2;

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

                    var prpertyRegexMatches = statisticsPropertyRegex.Matches(responseFromServer);

                    foreach (Match match in prpertyRegexMatches)
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
                        playerStatistics.GameweekId = gameweekId;
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

            var totalNewStatisticsCount = dbFootballPlayerIds.Count * StatisticsTypeCount;

            if (totalNewStatisticsCount != newGameweekStatisticsCollection.Count)
            {
                //something went wrong
                return;
            }
            else
            {
                // make backUp for old gameweek 0
                // delete all gameweek 0
                // replace with new collection
                // update database
            }

            //this.db.AddRange(totalStatistics);
            //var result = this.db.SaveChanges();
        }

        private void CreateNewGameweekStatistics(List<int> dbFootballPlayerIds)
        {
            var gameweekNumber = 2;
            var playerIdTest = 5140;
            var footballPlayer = this.db.FootballPlayers.Find(playerIdTest);
            var gameweek = this.db.GameWeeks.FirstOrDefault(gw => gw.Number < gameweekNumber/* && gw.Number > 0*/);

            if (footballPlayer == null || gameweek == null)
            {
                return;
            }

            // gameweek 0
            var zero = this.db.DefenceStatistics
                .FirstOrDefault(x => x.GameweekId == 1 && x.PlayerId == playerIdTest);

            // all without gameweek 0
            var defenceList = this.db.DefenceStatistics
                .Where(ds => ds.Gameweek != gameweek && ds.FootballPlayer == footballPlayer)
                .ToList();

            // sum of all without gameweek 0
            var defenceStatistics = new DefenceStatistics
            {
                SuccessfulFiftyFifties = (short)defenceList.Sum(x => x.SuccessfulFiftyFifties),
                ErrorsLeadingToGoal = (short)defenceList.Sum(x => x.ErrorsLeadingToGoal),
                AerialBattlesLost = (short)defenceList.Sum(x => x.AerialBattlesLost),
                AerialBattlesWon = (short)defenceList.Sum(x => x.AerialBattlesWon),
                HeadedClearance = (short)defenceList.Sum(x => x.HeadedClearance),
                LastManTackles = (short)defenceList.Sum(x => x.LastManTackles),
                Interceptions = (short)defenceList.Sum(x => x.Interceptions),
                GoalsConceded = (short)defenceList.Sum(x => x.GoalsConceded),
                BlockedShots = (short)defenceList.Sum(x => x.BlockedShots),
                CleanSheets = (short)defenceList.Sum(x => x.CleanSheets),
                Clearances = (short)defenceList.Sum(x => x.Clearances),
                Recoveries = (short)defenceList.Sum(x => x.Recoveries),
                DuelsLost = (short)defenceList.Sum(x => x.DuelsLost),
                DuelsWon = (short)defenceList.Sum(x => x.DuelsWon),
                OwnGoals = (short)defenceList.Sum(x => x.OwnGoals),
                Tackles = (short)defenceList.Sum(x => x.Tackles),
            };
        }
    }
}
    