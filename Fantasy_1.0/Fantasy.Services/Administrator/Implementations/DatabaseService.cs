using System;
using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models.Players;
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
using Fantasy.Data.Models.Statistics;

namespace Fantasy.Services.Administrator.Implementations
{
    public class DatabaseService : IDatabaseService
    {
        private readonly FantasyDbContext db;

        public DatabaseService(FantasyDbContext db)
        {
            this.db = db;
        }

        public string SeedPlayers()
        {
            var fileContentPlayer = System.IO.File.ReadAllText("wwwroot/JsonFiles/players.json");
            var fileContentPlayerInfo = System.IO.File.ReadAllText("wwwroot/JsonFiles/playersInfos.json");

            var players = JsonConvert.DeserializeObject<List<FootballPlayerJsonModel>>(fileContentPlayer);

            if (!this.db.FootballPlayers.Any())
            {
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

                var playersInfo = JsonConvert.DeserializeObject<List<FootballPlayerJsonInfo>>(fileContentPlayerInfo);
                var infos = playersInfo.To<FootballPlayerInfo>().ToList();

                this.db.AddRange(infos);
                this.db.SaveChanges();

                return $"{result} players have been seeded!";
            }


            //var fixtures = this.db.Fixtures.To<FixtureJsonModel>().ToList();
            //File.WriteAllText("wwwroot/JsonFiles/fixturesGameweek1.json",
            //    JsonConvert.SerializeObject(fixtures));

          

            return "The players have been seeded already!";
        }

        public string SeedStatistics()
        {
            if (this.db.AttackStatistics.Any())
            {
                return "Don't!";
            }

            var regex = new Regex("<span class=\"stat\">([A-Za-z\\ ]+)   <span.+\\s+([0-9\\.\\,]+)");
            var ids = this.db.FootballPlayers.Select(p => p.Id).ToList();
            var totalStatistics = new List<BaseStatistics>();

            foreach (var id in ids)
            {
                Console.WriteLine(id);
                var properties = new Dictionary<string, string>();

                var gameweekId = 1;

                var responseFromServer = string.Empty;
                var url = $"https://www.premierleague.com/players/{id}/player/stats";
                var request = WebRequest.Create(url);
                request.Credentials = CredentialCache.DefaultCredentials;
                var response = request.GetResponse();

                using (var dataStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(dataStream);
                    responseFromServer = reader.ReadToEnd();

                    foreach (Match match in regex.Matches(responseFromServer))
                    {
                        var key = match.Groups[1].ToString().Replace(" ", "");
                        var value = match.Groups[2].ToString().Replace(",", "");

                        if (!properties.ContainsKey(key))
                        {
                            properties.Add(key, value);
                        }
                    }

                    var statistics = new List<BaseStatistics>
                    {
                        new AttackStatistics(),
                        new MatchStatistics(),
                        new DefenceStatistics(),
                        new TeamPlayStatistics(),
                        new DisciplineStatistics(),
                        new GoalkeepingStatistics(),
                    };

                    foreach (var stat in statistics)
                    {
                        stat.GameweekId = gameweekId;
                        stat.PlayerId = id;

                        foreach (var kvp in properties)
                        {
                            stat
                                .GetType()
                                .GetProperty(kvp.Key,
                                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                                ?.SetValue(stat, short.Parse(kvp.Value));
                        }
                    }
                    totalStatistics.AddRange(statistics);
                }

                response.Close();

            }

            this.db.AddRange(totalStatistics);
            this.db.SaveChanges();




            var attackStat = this.db.AttackStatistics.ToList();
            var matchStat = this.db.MatchStatistics.ToList();
            var defenceStat = this.db.DefenceStatistics.ToList();
            var teamStat = this.db.TeamPlayStatistics.ToList();
            var disciplineStat = this.db.DisciplineStatistics.ToList();
            var goalkeepingStat = this.db.GoalkeepingStatistics.ToList();

            File.WriteAllText("wwwroot/JsonFiles/attackStat.json",
                JsonConvert.SerializeObject(attackStat));
            File.WriteAllText("wwwroot/JsonFiles/matchStat.json",
                JsonConvert.SerializeObject(matchStat));
            File.WriteAllText("wwwroot/JsonFiles/defenceStat.json",
                JsonConvert.SerializeObject(defenceStat));
            File.WriteAllText("wwwroot/JsonFiles/teamStat.json",
                JsonConvert.SerializeObject(teamStat));
            File.WriteAllText("wwwroot/JsonFiles/disciplineStat.json",
                JsonConvert.SerializeObject(disciplineStat));
            File.WriteAllText("wwwroot/JsonFiles/goalkeepingStat.json",
                JsonConvert.SerializeObject(goalkeepingStat));

            return null;
        }
    }
}
    