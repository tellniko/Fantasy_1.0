using Fantasy.Common;
using Fantasy.Data.Models;
using Fantasy.Services;
using Fantasy.Services.Models;
using Fantasy.Web.Infrastructure.Extensions;
using Fantasy.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy.Web.Controllers
{
    using static GlobalConstants;
    using static SortingExtension;

    [Authorize]
    public class SquadController : Controller
    {
        private const string ErrorMessage = "Something went wrong! Please try again.";
        private const string SuccessMessage = "Well done! You are ready to kick balls now!";

        private readonly UserManager<FantasyUser> userManager;
        private readonly ISquadService squad;
        private readonly IFootballPlayerService players;
        private readonly IFixtureService fixtures;
        private readonly IGameweekService gamweeks;

        public SquadController(
            UserManager<FantasyUser> userManager, 
            ISquadService squad, 
            IFootballPlayerService players, 
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

            var squadExists = await this.squad.SquadExistsAsync(userId);

            if (!squadExists)
            {
                return RedirectToAction(nameof(Create), new{ userId });
            }

            var nextGameweek = await this.gamweeks.GetNext(DateTime.UtcNow);
            //todo validate date start
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
            var userId = this.userManager.GetUserId(User);

            var validSquad = await this.squad.ValidateFirstTeamAsync(ids, userId);

            if (!validSquad)
            {
                this.ViewBag.ActionGetSystem = nameof(GetSystem);
                this.ViewBag.ActionGetBench = nameof(GetBench);
                this.ViewBag.Controller = nameof(SquadController).ToFirstWord();

                this.TempData.AddErrorMessage(ErrorMessage);

                return this.View();
            }

            await this.squad.SaveFirstTeamAsync(ids, userId);
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create(string userId)
        {
            this.ViewBag.Action = nameof(GetPartialPlayers);
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
                this.TempData.AddErrorMessage(ErrorMessage);

                return RedirectToAction(nameof(Create), new { userId });
            }

            if (result == null)
            {
                return BadRequest();
            }

            this.TempData.AddSuccessMessage(SuccessMessage);

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

        public async Task<IActionResult> GetPartialPlayers(string clubId,
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

            this.ViewBag.Action = nameof(GetPartialPlayers);
            this.ViewBag.Controller = nameof(SquadController).ToFirstWord();

            return PartialView("_PartialPlayersPagination", model);
        }


        public IActionResult GameweekHistory()
        {

            this.ViewBag.Action = nameof(GetPartialGameweekHistorySquad);
            this.ViewBag.Controller = nameof(SquadController).ToFirstWord();

            return View();
        }

        public async Task<IActionResult> GetPartialGameweekHistorySquad(int gameweekId = 1)
        {
            var userId = this.userManager.GetUserId(User);

            var result = await this.squad.GetHistorySquad(userId, gameweekId);

            if (result == null)
            {
                return BadRequest();
            }

            return PartialView("_PartialSquad", result.OrderBy(x => SortByPosition(x.Position)).ToList());
        }
    }
}

