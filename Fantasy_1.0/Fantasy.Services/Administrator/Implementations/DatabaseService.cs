using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models.Players;
using Fantasy.Services.Administrator.Models.Db;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            //var gameweek = this.db.GameWeeks
            //    .Include(gw => gw.Fixtures)
            //    .ThenInclude(f => f.HomeTeam )
            //    .Include(gw => gw.Fixtures)
            //    .ThenInclude(f => f.AwayTeam)
            //    .FirstOrDefault(gw => gw.Number == 1);

            //if (gameweek != null)
            //{
            //    foreach (var fixture in gameweek.Fixtures)
            //    {
            //        var homeTeam = fixture.HomeTeam;
            //        var awayTeam = fixture.AwayTeam;

            //        var playersHomeTeam = homeTeam.Squad;
            //        var playersAwayTeam = awayTeam.Squad;
            //    }
            //}

            


            return "The players have been seeded already!";
        }
    }
}
    