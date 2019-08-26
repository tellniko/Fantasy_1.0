using Fantasy.Common;
using Fantasy.Data.Models.Common;
using Fantasy.Services;
using Fantasy.Services.Models;
using Fantasy.Web.Infrastructure.Extensions;
using Fantasy.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Fantasy.Web.Controllers
{
    using static GlobalConstants;

    [Authorize]
    public class SquadController : Controller
    {

        private readonly UserManager<FantasyUser> userManager;
        private readonly ISquadService squad;
        private readonly IPlayerService players;
        private readonly IFixtureService fixtures;
        private readonly IGameweekService gamweeks;

        public SquadController(
            UserManager<FantasyUser> userManager, 
            ISquadService squad, 
            IPlayerService players, 
            IFixtureService fixtures, 
            IGameweekService gamweeks)
        {
            this.userManager = userManager;
            this.squad = squad;
            this.players = players;
            this.fixtures = fixtures;
            this.gamweeks = gamweeks;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.userManager.GetUserId(User);

            var squadExists = await this.squad.SquadExists(userId);

            if (!squadExists)
            {
                return RedirectToAction(nameof(Create), new{ userId });
            }

            var nextGameweek = await this.gamweeks.GetNext(DateTime.UtcNow);

            var model = new CurrentSquadViewModel
            {
                Squad = await this.squad.GetCurrentSquad(userId, nextGameweek.Id),
                Fixtures = await this.fixtures.GetByIdAsync<FixtureServiceModel>(nextGameweek.Id),
                GameweekStartDate = nextGameweek.Start,
            };

            return View(model);
        }

        public IActionResult Manage()
        {
            this.ViewBag.ActionGetSystem = nameof(GetSystem);
            this.ViewBag.ActionGetBench = nameof(GetBench);
            this.ViewBag.Controller = nameof(SquadController).ToFirstWord();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Manage(string ids)
        {
            if (ids == null)
            {
                return this.BadRequest();
            }
            var userId = this.userManager.GetUserId(User);

            var validSquad = await this.squad.ValidateFirstTeamAsync(ids, userId);
            if (!validSquad)
            {
                return BadRequest();
            }

            await this.squad.SaveFirstTeam(ids, userId);
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create(string userId)
        {
            this.ViewBag.Action = nameof(GetPartialPlayersAsync);
            this.ViewBag.Controller = nameof(SquadController).ToFirstWord();

            var model = new UserSquadFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserSquadFormModel model)
        {
            var userId = this.userManager.GetUserId(User);

            var validationResult = await this.squad.ValidateSquadAsync(model.GetPlayerIds());
            if (!validationResult || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await this.squad.CreateSquadAsync(model.GetPlayerIds(), userId);

            if (result == false)
            {
                TempData.AddErrorMessage("Your squad have not been created! Please try again.");

                return RedirectToAction(nameof(Create), new { userId });
            }

            if (result == null)
            {
                return BadRequest();
            }

            this.TempData.AddSuccessMessage("Well done! You are ready to kick balls now!");

            return RedirectToAction(nameof(Manage));
        }

        public async Task<IActionResult> GetBench()
        {
            var userId = this.userManager.GetUserId(User);

            var squad = await this.squad.GetSquadAsync(userId);

            return PartialView("_PartialBench", squad);
        }

        public IActionResult GetSystem(string system)
        {
            if (system == string.Empty)
            {
                return BadRequest();
            }

            return PartialView($"_PartialSystem{system}");
        }

        public async Task<IActionResult> GetPartialPlayersAsync(string clubId,
            string positionId,
            string playerName,
            string order,
            int page = 1)
        {
            var model = new PlayersListingViewModel
            {
                Players = await this.players
                    .GetAllWithPaginationAsync<FootballPlayerServiceModel>(clubId, positionId, playerName, order, page, PlayersListingPageSize),
                CurrentPage = page,
            };

            this.ViewBag.Action = nameof(GetPartialPlayersAsync);
            this.ViewBag.Controller = nameof(SquadController).ToFirstWord();

            return PartialView("_PartialPlayersPagination", model);
        }


        public async Task<IActionResult> Test()
        {
            var userId = this.userManager.GetUserId(User);

            await this.squad.Test(userId);

            return View();
        }
    }
}

