using Fantasy.Common.Mapping;
using Fantasy.Services.Administrator;
using Fantasy.Services.Administrator.Models;
using Fantasy.Web.Areas.Administrator.Models;
using Fantasy.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy.Web.Areas.Administrator.Controllers
{
    public class GameweeksController : AdministratorController
    {
        private readonly IGameweekService gameweeks;


        public GameweeksController(IGameweekService gameweeks)
        {
            this.gameweeks = gameweeks;

        }

        public IActionResult ViewGameweeks()
        {
            var gameweeks = new GameweekListingViewModel
            {
                Gameweeks = this.gameweeks.GetAll().To<GameWeekViewModel>()
            };

            return View(gameweeks);
        }


        //public IActionResult EditGameweek(int id)
        //{
        //    var gameweek = this.adminService
        //        .Get(id)
        //        .To<GameWeekViewModel>();

        //    if (gameweek == null)
        //    {
        //        return BadRequest();
        //    }

        //    return View(gameweek);
        //}

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

            return RedirectToAction(nameof(ViewGameweeks));
        }

        
    }
}
