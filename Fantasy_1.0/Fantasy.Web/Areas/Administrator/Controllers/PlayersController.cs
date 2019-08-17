using System;
using Fantasy.Services;
using Fantasy.Services.Administrator.Models.Db;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models.FootballPlayers;
using Fantasy.Services.Administrator.Models;
using Fantasy.Web.Infrastructure.Extensions;

namespace Fantasy.Web.Areas.Administrator.Controllers
{
    public class PlayersController : AdministratorController
    {
        private readonly IPlayerService players;
      

        public PlayersController(IPlayerService players, FantasyDbContext db)
        {
            this.players = players;
        }

        public async Task<IActionResult> Edit(int id)
        {
            Console.WriteLine();


            var player = await this.players.GetByIdAsync<FootballPlayerEditServiceModel>(id);

            return View(player);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FootballPlayerEditServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!await this.players.Exists(model.Id))
            {
                this.TempData.AddErrorMessage("Player does not exists");
                return RedirectToAction(nameof(Index));
            }

            var successfulResult = await this.players.Edit(model);

            if (!successfulResult)
            {
                this.TempData.AddErrorMessage("Something went wrong bro!");
                return RedirectToAction(nameof(Edit), new { model });
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(FootballPlayerAddServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await this.players.Exists(model.Id))
            {
                this.TempData.AddErrorMessage("A player with the given id exists! Try with id in range [1-1500]!");
                return View(model);
            }

            //todo refactor
            var result = this.players.Add(model);

            if (!result)
            {
                this.TempData.AddErrorMessage("Error");
            }

            this.TempData.AddSuccessMessage("Success");

            return RedirectToAction(nameof(Index));
        }
    }
}
