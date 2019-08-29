using Fantasy.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Fantasy.Data.Models;

namespace Fantasy.Services.Administrator.Implementations
{
    public class ImportService : IImportService
    {
        private readonly FantasyDbContext db;

        public ImportService(FantasyDbContext db)
        {
            this.db = db;
        }

        public int ImportPlayers()
        {
            //todo constants

            var players = JsonConvert.DeserializeObject<List<FootballPlayer>>(
                    File.ReadAllText("wwwroot/JsonFiles/footballPlayers.json"))
                .ToList();

            foreach (var footballPlayer in players)
            {
                for (int i = 1; i <= 38; i++)
                {
                    footballPlayer.GameweekPoints.Add(new GameweekPoints
                    {
                        Points = 0,
                        GameweekId = i,
                    });
                }
            }

            var infos = JsonConvert.DeserializeObject<List<FootballPlayerInfo>>(
                    File.ReadAllText("wwwroot/JsonFiles/footballPlayerInfos.json"))
                .ToList();

            if (this.db.FootballPlayers.Any())
            {
                return -1;
            }

            var result = 0;

            db.AddRange(players);

            db.Database.OpenConnection();
            try
            {
                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.FootballPlayers ON");
                this.db.AddRange(infos);

                result += db.SaveChanges() / 2;

                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.FootballPlayers OFF");
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                db.Database.CloseConnection();
            }

            return result;
        }

        public string ImportStatistics(int gameweekId)
        {
            var statistics = new List<GameweekStatistics>();

            try
            {
                statistics.AddRange(JsonConvert.DeserializeObject<List<GameweekStatistics>>
                    (File.ReadAllText($"wwwroot/JsonFiles/GW{gameweekId}/statisticsGW{gameweekId}.json")));
         
            }
            catch (Exception)
            {
                return null;
            }

            this.db.AddRange(statistics);

            var result = this.db.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return result.ToString();
        }
    }
}
