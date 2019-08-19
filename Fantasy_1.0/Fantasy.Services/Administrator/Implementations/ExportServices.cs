using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Fantasy.Data;
using Newtonsoft.Json;
using  System.Linq;
using Fantasy.Common.Mapping;
using Fantasy.Services.Administrator.Models.Db;

namespace Fantasy.Services.Administrator.Implementations
{
    public class ExportServices : IExportServices
    {
        private readonly FantasyDbContext db;

        public ExportServices(FantasyDbContext db)
        {
            this.db = db;
        }

        public void ExportFootballPlayers()
        {
            //return;
            //var players = this.db.FootballPlayers.To<FootballPlayerJsonModel>().ToList();
            //File.WriteAllText("wwwroot/JsonFiles/footballPlayers.json", JsonConvert.SerializeObject(players));
        }

        public void ExportFootballPlayerInfos()
        {
            return;
            var infos = this.db.FootballPlayerInfos.To<FootballPlayerInfoJsonModel>().ToList();
            File.WriteAllText("wwwroot/JsonFiles/footballPlayerInfos.json", JsonConvert.SerializeObject(infos));
        }

        public int ExportStatistics(int gameweekId)
        {
            var gameweek = this.db.GameWeeks.Find(gameweekId);
            if (gameweek == null)
            {
                return 0;
            }

            try
            {
                var attackStatistics = this.db.AttackStatistics.Where(s => s.Gameweek == gameweek).ToList();
                var matchStatistics = this.db.MatchStatistics.Where(s => s.Gameweek == gameweek).ToList();
                var defenceStatistics = this.db.DefenceStatistics.Where(s => s.Gameweek == gameweek).ToList();
                var teamPlayStatistics = this.db.TeamPlayStatistics.Where(s => s.Gameweek == gameweek).ToList();
                var disciplineStatistics = this.db.DisciplineStatistics.Where(s => s.Gameweek == gameweek).ToList();
                var goalkeepingStatistics = this.db.GoalkeepingStatistics.Where(s => s.Gameweek == gameweek).ToList();

                File.WriteAllText($"wwwroot/JsonFiles/GW{gameweek.Id}/attackStatGW{gameweek.Id}.json",
                    JsonConvert.SerializeObject(attackStatistics));
                File.WriteAllText($"wwwroot/JsonFiles/GW{gameweek.Id}/matchStatGW{gameweek.Id}.json",
                    JsonConvert.SerializeObject(matchStatistics));
                File.WriteAllText($"wwwroot/JsonFiles/GW{gameweek.Id}/defenceStatGW{gameweek.Id}.json",
                    JsonConvert.SerializeObject(defenceStatistics));
                File.WriteAllText($"wwwroot/JsonFiles/GW{gameweek.Id}/teamPlayStatGW{gameweek.Id}.json",
                    JsonConvert.SerializeObject(teamPlayStatistics));
                File.WriteAllText($"wwwroot/JsonFiles/GW{gameweek.Id}/disciplineStatGW{gameweek.Id}.json",
                    JsonConvert.SerializeObject(disciplineStatistics));
                File.WriteAllText($"wwwroot/JsonFiles/GW{gameweek.Id}/goalkeepingStatGW{gameweek.Id}.json",
                    JsonConvert.SerializeObject(goalkeepingStatistics));
            }
            catch (Exception)
            {
                return -1;
            }

            return 1;
        }
    }
}
