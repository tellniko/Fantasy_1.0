using Fantasy.Data;
using Fantasy.Services;
using Fantasy.Services.Administrator.Models;
using Fantasy.Web.Areas.Administrator.Models;
using Fantasy.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy.Web.Areas.Administrator.Controllers
{
    public class PlayersController : AdministratorController
    {
        private readonly IPlayerService players;
        private readonly FantasyDbContext db;

        public PlayersController(IPlayerService players, FantasyDbContext db)
        {
            this.players = players;
            this.db = db;
        }

        public async Task<IActionResult> Edit(int id)
        {
            var player = await this.players.GetByIdAsync<FootballPlayerServiceModel>(id);

            if (player == null)
            {
                return BadRequest();
            }

            var model = new FootballPlayerViewModel
            {
                Clubs = this.GetClubs(),
                Positions = this.GetPositions(),
                Player = player
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FootballPlayerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Clubs = this.GetClubs();
                model.Positions = this.GetPositions();

                return View(model);
            }

            if (!await this.players.Exists(model.Player.Id))
            {
                this.TempData.AddErrorMessage("Player does not exists");

                return RedirectToAction(nameof(Index));
            }

            var successfulResult = await this.players.Edit(model.Player);

            if (!successfulResult)
            {
                this.TempData.AddErrorMessage("Something went wrong or you did not make any changes!");

                return RedirectToAction(nameof(Edit), new { model });
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            var model = new FootballPlayerViewModel
            {
                Clubs = this.GetClubs(),
                Positions = this.GetPositions(),
            };

            return View(model);
        }


        //todo refactor
        [HttpPost]
        public async Task<IActionResult> Add(FootballPlayerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Clubs = this.GetClubs();
                model.Positions = this.GetPositions();

                return View(model);
            }

            if (await this.players.Exists(model.Player.Id))
            {
                this.TempData.AddErrorMessage("A player with the given id exists! Try with id in range [1-1500]!");
                model.Clubs = this.GetClubs();
                model.Positions = this.GetPositions();

                return View(model);
            }

            //todo refactor
            var result = this.players.Add(model.Player);

            if (!result)
            {
                this.TempData.AddErrorMessage("Error");
            }

            this.TempData.AddSuccessMessage("Success");

            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> GetClubs()
        {
            return this.db.FootballClubs
                .Select(fc => new SelectListItem
                {
                    Text = fc.Name,
                    Value = fc.Id.ToString()
                })
                .ToList();
        }

        private List<SelectListItem> GetPositions()
        {
            return this.db.FootballPlayerPositions
                .Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                })
                .ToList();
        }

        private List<SelectListItem> GetGameweeks()
        {
            return this.db.GameWeeks
                .Select(gw => new SelectListItem
                {
                    Text = gw.Name,
                    Value = gw.Id.ToString(),
                })
                .ToList();
        }
    }
}
