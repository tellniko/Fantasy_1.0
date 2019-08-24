using Fantasy.Data;
using Fantasy.Services.Administrator.Models;
using Fantasy.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Fantasy.Web.Areas.Administrator.Controllers
{
    public class StatisticsController : AdminController
    {
        private readonly IStatisticsService statisticsService;
        private readonly FantasyDbContext db;

        public StatisticsController(FantasyDbContext db, IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
            this.db = db;

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


            var result = this.statisticsService.Seed(gameweek.Id);

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
