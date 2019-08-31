using Fantasy.Common;
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
    using static  GlobalConstants;

    public class PlayersController : AdminController
    {
        private readonly IFootballPlayerService players;
        private IFootballClubService clubs;
        private readonly FantasyDbContext db;

        public PlayersController(IFootballPlayerService players, FantasyDbContext db, IFootballClubService clubs)
        {
            this.players = players;
            this.db = db;
            this.clubs = clubs;
        }

        public async Task<IActionResult> Edit(int id)
        {
            var player = await this.players.GetByIdAsync<FootballPlayerFormModel>(id);

            if (player == null)
            {
                return BadRequest();
            }

            var model = new FootballPlayerViewModel
            {
                Clubs = await this.GetClubs(),
                Positions = this.GetPositions(),
                Player = player,
                Gameweeks = this.GetGameweeks()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FootballPlayerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Clubs = await this.GetClubs();
                model.Positions = this.GetPositions();

                return View(model);
            }

            if (!await this.players.Exists(model.Player.Id))
            {
                return BadRequest();
            }

            var successfulResult = await this.players.Edit(model.Player);

            if (!successfulResult)
            {
                this.TempData.AddErrorMessage("Something went wrong or you did not make any changes!");

                return RedirectToAction(nameof(Edit), new { model });
            }

            this.TempData.AddSuccessMessage($"Successfully edited player {model.Player.InfoName} with id {model.Player.Id}.");


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Add()
        {
            var model = new FootballPlayerViewModel
            {
                Clubs =  await this.GetClubs(),
                Positions = this.GetPositions(),
                Player = new FootballPlayerFormModel
                {
                    InfoBigImgUrl = DefaultPlayerBigImageUrl,
                    InfoSmallImgUrl = DefaultPlayerSmallImageUrl
                }
            };

            return View(model);
        }


        //todo refactor
        [HttpPost]
        public async Task<IActionResult> Add(FootballPlayerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Clubs = await this.GetClubs();
                model.Positions = this.GetPositions();

                return View(model);
            }

            if (await this.players.Exists(model.Player.Id))
            {
                this.TempData.AddErrorMessage("A player with the given id already exists! Try with id in range [1-1500]!");
                model.Clubs = await this.GetClubs();
                model.Positions = this.GetPositions();

                return View(model);
            }

            //todo refactor
            var result = this.players.Add(model.Player);

            if (result == 0)
            {
                this.TempData.AddErrorMessage("The player has not been added to the database!");
            }

            this.TempData.AddSuccessMessage("The player has been successfully added to the database.");

            return RedirectToAction(nameof(Index));
        }

        private async Task<List<SelectListItem>> GetClubs()
        {
            var all = await this.clubs.GetAll<FootballClubDropDownModel>();

                return all
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
            return this.db.Gameweeks
                .Select(gw => new SelectListItem
                {
                    Text = gw.Name,
                    Value = gw.Id.ToString(),
                })
                .ToList();
        }
    }
}
