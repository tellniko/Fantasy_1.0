using Fantasy.Data;
using Fantasy.Services.Administrator;
using Fantasy.Services.Administrator.Models;
using Fantasy.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy.Web.Areas.Administrator.Controllers
{
    public class GameweeksController : AdminController
    {
        private readonly IGameweekService gameweeks;
        private readonly IFixtureService fixtures;
        private readonly FantasyDbContext context;


        public GameweeksController(IGameweekService gameweeks, IFixtureService fixtures, FantasyDbContext context)
        {
            this.gameweeks = gameweeks;
            this.fixtures = fixtures;
            this.context = context;
        }

        public IActionResult All()
        {
            return View(this.gameweeks.GetAll<GameweekServiceModel>());
        }

        public IActionResult Edit(int id)
        {
            var gamweek = this.gameweeks.GetById<GameweekServiceModel>(id);
            if (gamweek == null)
            {
                return BadRequest();
            }

            return View(gamweek);
        }

        [HttpPost]
        public IActionResult Edit(GameweekServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = this.gameweeks.Edit(model);
            if (result == null)
            {
                return BadRequest();
            }

            if (result == false)
            {
                this.TempData.AddErrorMessage($"{model.Name} have not been modified.");
            }
            else
            {
                this.TempData.AddSuccessMessage($"{model.Name} has been edited successfully.");
            }

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Gameweek()
        {
            //var gw = await this.gameweeks.GetByStart(DateTime.UtcNow.AddDays(12));
            var gw = await this.gameweeks.GetByStart(DateTime.UtcNow.Subtract(new TimeSpan(5,0,0,0)));



            var player = this.context.FootballPlayers
                .Include(fp => fp.MatchStatistics)
                .Where(x => x.MatchStatistics.FirstOrDefault(s => s.GameweekId == 1).Wins == 0)
                .FirstOrDefault();
                

            return View(gw);
        }
    }
}
