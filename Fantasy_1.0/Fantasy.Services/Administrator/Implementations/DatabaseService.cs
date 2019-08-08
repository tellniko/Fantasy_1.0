using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models.Players;
using Fantasy.Services.Administrator.Models.Db;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
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

            if (!this.db.Players.Any())
            {
                var allPlayers = players.To<Player>().ToList();
                var result = 0;

                db.AddRange(allPlayers);
                db.Database.OpenConnection();

                try
                {
                    db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Players ON");
                    result += db.SaveChanges();
                    db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Players OFF");
                }
                finally
                {
                    db.Database.CloseConnection();
                }

                var playersInfo = JsonConvert.DeserializeObject<List<FootballPlayerJsonInfo>>(fileContentPlayerInfo);
                var infos = playersInfo.To<PlayerPersonalInfo>().ToList();

                this.db.AddRange(infos);
                this.db.SaveChanges();

                return $"{result} players had been seeded!";
            }

            return "The players had been seeded already!";
        }
    }
}
    