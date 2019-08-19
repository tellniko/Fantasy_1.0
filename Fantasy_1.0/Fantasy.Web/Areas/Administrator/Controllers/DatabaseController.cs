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
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult ImportPlayers()
        {
            var result = this.databaseServices.ImportPlayers();

            if (result == -1)
            {
                this.TempData.AddErrorMessage("The players have been seeded already!");
            }
            else if(result == 0)
            {
                this.TempData.AddSuccessMessage($"There is a problem with the Json file or database IDENTITY_INSERT!");
            }
            else
            {
                this.TempData.AddSuccessMessage($"{result} players have been seeded!");
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult SeedStatistics()
        {
            var model = this.GetGameweeks();

            return View(model);
        }


        [HttpPost]
        public IActionResult SeedStatistics(int gameweekId)
        {
            var gameweek = this.db.GameWeeks.FirstOrDefault(gw => gw.Id == gameweekId);

            if (gameweek == null)
            {
                return BadRequest();
            }


            var result = this.databaseServices.SeedStatistics(gameweek.Id);

            if (result == null)
            {
                this.TempData.AddErrorMessage("Statistics for this gameweek is already updated!");
            }
            else
            {
                this.TempData.AddSuccessMessage(result);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ImportStatistics()
        {
            var model = this.GetGameweeks();

            return View(model);
        }

        [HttpPost]
        public IActionResult ImportStatistics(int gameweekId)
        {
            Console.WriteLine();

            var result = this.databaseServices.ImportStatistics(gameweekId);

            if (result == null)
            {
                this.TempData.AddErrorMessage("No changes have been made!");
            }
            else if(int.TryParse(result, out var number))
            {
                this.TempData.AddSuccessMessage($"{number} changes have been made!");
            }
            else
            {
                this.TempData.AddErrorMessage(result);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ExportPlayersJson()
        {
            this.databaseServices.ExportFootballPlayers();

            this.TempData.AddSuccessMessage("File created!");

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ExportPlayerInfosJson()
        {
            this.databaseServices.ExportFootballPlayerInfos();

            this.TempData.AddSuccessMessage("File created!");

            this.TempData.AddErrorMessage("Disabled!");


            return RedirectToAction(nameof(Index));
        }


        public IActionResult ExportStatisticsJson()
        {
            var model = this.GetGameweeks();
            return View(model);
        }

        [HttpPost]
        public IActionResult ExportStatisticsJson(int gameweekId)
        {
            //this.TempData.AddErrorMessage("Disabled!");
            //return RedirectToAction(nameof(Index));

            var result =  this.databaseServices.ExportStatistics(gameweekId);

            if (result == null)
            {
                return BadRequest();
            }

            this.TempData.AddSuccessMessage(result);

            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> GetGameweeks()
        {
            return this.db.GameWeeks
                .OrderBy(x => x.Id)
                .Select(gw => new SelectListItem
                {
                    Text = gw.Name,
                    Value = gw.Id.ToString()
                })
                .ToList();
        }
    }
}
