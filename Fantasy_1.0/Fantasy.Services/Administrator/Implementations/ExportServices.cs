using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Services.Administrator.Models.Db;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace Fantasy.Services.Administrator.Implementations
{
    public class ExportServices : IExportServices
    {
        private readonly FantasyDbContext db;

        public ExportServices(FantasyDbContext db)
        {
            this.db = db;
        }

        public bool ExportFootballPlayers()
        {
            try
            {
                File.WriteAllText("wwwroot/JsonFiles/footballPlayers.json", JsonConvert.SerializeObject(
                    this.db.FootballPlayers.To<FootballPlayerJsonModel>().ToList()));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool ExportFootballPlayerInfos()
        {
            try
            {
                File.WriteAllText("wwwroot/JsonFiles/footballPlayerInfos.json", JsonConvert.SerializeObject(
                    this.db.FootballPlayerInfos.To<FootballPlayerInfoJsonModel>().ToList()));
            }
            catch (Exception)
            {
                return false;
            }   
            
            return true;
        }

        public bool? ExportStatistics(int gameweekId)
        {
            var gameweek = this.db.Gameweeks.Find(gameweekId);
            if (gameweek == null)
            {
                return null;
            }

            try
            {
                var statistics = this.db.GameweekStatistics.Where(s => s.Gameweek == gameweek).ToList();

                var stat = JsonConvert.SerializeObject(statistics);

                File.WriteAllText($"wwwroot/JsonFiles/GW{gameweek.Id}/GW{gameweek.Id}.json",
                    JsonConvert.SerializeObject(statistics));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
