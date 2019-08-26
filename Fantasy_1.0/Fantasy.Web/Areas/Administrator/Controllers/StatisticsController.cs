﻿using Fantasy.Data;
using Fantasy.Services.Administrator;
using Fantasy.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy.Web.Areas.Administrator.Controllers
{
    public class StatisticsController : AdminController
    {
        private readonly IStatisticsService statistics;
        private readonly FantasyDbContext db;

        public StatisticsController(FantasyDbContext db, IStatisticsService statistics)
        {
            this.statistics = statistics;
            this.db = db;

        }

        public IActionResult UpdatePoints()
        {
            var model = this.GetGameweeks();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePoints(int gameweekId)
        {
            var result = await this.statistics.UpdateFootballPlayersPoints(gameweekId);

            if (result == null)
            {
                this.TempData.AddErrorMessage("Something went wrong!");
            }
            else
            {
                this.TempData.AddSuccessMessage($"{result} updates have been made.");
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Seed()
        {
            var model = this.GetGameweeks();

            return View(model);
        }

        [HttpPost]
        public IActionResult Seed(int gameweekId)
        {
            var gameweek = this.db.Gameweeks.FirstOrDefault(gw => gw.Id == gameweekId);

            if (gameweek == null)
            {
                return BadRequest();
            }


            var result = this.statistics.Seed(gameweek.Id);

            if (result == null)
            {
                this.TempData.AddErrorMessage($"Statistics for {gameweek.Name} has been updated already!");
            }
            else
            {
                this.TempData.AddSuccessMessage(result);
            }

            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> GetGameweeks()
        {
            return this.db.Gameweeks
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
