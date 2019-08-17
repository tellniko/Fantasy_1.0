using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Services.Administrator;
using Fantasy.Services.Administrator.Models.Db;
using Fantasy.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Fantasy.Web.Areas.Administrator.Controllers
{
    public class DatabaseController : AdministratorController
    {
        private readonly IDatabaseService databaseServices;
        private readonly FantasyDbContext db;
        

        public DatabaseController(IDatabaseService database, FantasyDbContext db)
        {
            this.databaseServices = database;
            this.db = db;
        }

        public IActionResult SeedPlayers()
        {
            this.TempData.AddSuccessMessage(this.databaseServices.SeedPlayers());
            return RedirectToAction(nameof(Index));
        }

        public IActionResult SeedStatistics()
        {
            this.databaseServices.SeedStatistics();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ExportPlayersJson()
        {
            this.databaseServices.CreateJsonFilePlayers();

            this.TempData.AddSuccessMessage("File created!");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ExportPlayerInfosJson()
        {
            this.databaseServices.CreateJsonFilePlayerInfos();

            this.TempData.AddSuccessMessage("File created!");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ExportStatisticsJson(int gameweekNumber = 1)
        {
            
            return RedirectToAction(nameof(Index));


            var gameweek = this.db.GameWeeks.FirstOrDefault(gw => gw.Number == gameweekNumber);

            if (gameweek == null)
            {
                return BadRequest();
            }

            this.databaseServices.CreateJsonFilesStatistics(gameweek);

            this.TempData.AddSuccessMessage("Files created!");
            return RedirectToAction(nameof(Index));
        }
    }

   
}
