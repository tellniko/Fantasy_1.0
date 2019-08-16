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


            var player = await this.players.GetByIdAsync<FootballPlayerServiceModel>(id);

            return View(player);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FootballPlayerServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var successfulResult = await this.players.Edit(model);

            if (!successfulResult)
            {
                this.TempData.AddErrorMessage("Something went wrong bro!");
                return RedirectToAction(nameof(Edit), new { model });
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
