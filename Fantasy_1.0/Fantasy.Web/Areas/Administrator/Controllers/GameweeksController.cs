using Fantasy.Common.Mapping;
using Fantasy.Services.Administrator;
using Fantasy.Services.Administrator.Models;
using Fantasy.Web.Areas.Administrator.Models;
using Fantasy.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Fantasy.Web.Areas.Administrator.Controllers
{
    public class GameweeksController : AdministratorController
    {
        private readonly IGameweekService gameweeks;
        private readonly IFixtureService fixtures;


        public GameweeksController(IGameweekService gameweeks, IFixtureService fixtures)
        {
            this.gameweeks = gameweeks;
            this.fixtures = fixtures;
        }

        public IActionResult All()
        {
            var gameweeks = new GameweekListingViewModel
            {
                Gameweeks = this.gameweeks.GetAll().To<GameWeekViewModel>()
            };

            return View(gameweeks);
        }


        public IActionResult Edit(int id)
        {
            var gameweek = this.gameweeks
                .Get(id)
                .To<GameWeekViewModel>();

            if (gameweek == null)
            {
                return BadRequest();
            }

            return View(gameweek);
        }

        [HttpPost]
        public IActionResult Edit(GameWeekViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = this.gameweeks.Edit(model.To<GameweekServiceModel>());

            if (!success)
            {
                this.TempData.AddErrorMessage("Something went wrong! Try again.");

                return View(model);
            }

            this.TempData.AddSuccessMessage($"{model.Name} has been edited successfully.");

            return RedirectToAction(nameof(All));
        }

        public IActionResult Details(int id)
        {
            var gameweek = this.gameweeks.Get(id);
            var fixtures = this.fixtures.GetByGameweek(id);

            if (gameweek == null)
            {
                return BadRequest();
            }

            var model = new GameWeekDetailsViewModel
            {
                Gameweek = gameweek,
                Fixtures = fixtures,
            };

            return View(model);
        }
    }
}
