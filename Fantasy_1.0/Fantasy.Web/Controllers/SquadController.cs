using Fantasy.Data.Models.Common;
using Fantasy.Services;
using Fantasy.Services.Models;
using Fantasy.Web.Infrastructure;
using Fantasy.Web.Infrastructure.Extensions;
using Fantasy.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Fantasy.Common;

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

        public SquadController(UserManager<FantasyUser> userManager, ISquadService squad, IPlayerService players, IFixtureService fixtures)
        {
            this.userManager = userManager;
            this.squad = squad;
            this.players = players;
            this.fixtures = fixtures;
        }

        public async Task<IActionResult> Index()
        {
            //var testGameweeks = this.squad.SaveFirstTeam("", "");
            

            var userId = this.userManager.GetUserId(User);
            var test = await this.squad.GetCurrentSquad(userId, 4);

            var squad = await this.squad.GetSquadAsync(userId);

            if (squad.Count == 0)
            {
                return RedirectToAction(nameof(Create), new{ userId });
            }


            //todo get current fixture!!!!!

            var model = new SquadIndexViewModel
            {
                Squad = await this.squad.GetCurrentSquad(userId, 4),
                Fixtures = await this.fixtures.GetByIdAsync<FixtureServiceModel>(4)
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

            var result = await this.squad.ValidateFirstTeamAsync(ids, userId);
            if (!result)
            {
                return BadRequest();
            }

            await this.squad.SaveFirstTeam(ids, userId);

            return RedirectToAction(nameof(Index));
        }


        //public async Task<IActionResult> Index(string ids)
        //{
        //    var userId = this.userManager.GetUserId(User);

        //    var result = await this.squad.ValidateFirstTeam(ids, userId);


        //    return View();
        //}

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

            Console.WriteLine();
            if (result == false)
            {
                TempData.AddErrorMessage("Your squad have not been updated! Please try again.");

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

        public async Task<IActionResult> GetPartialPlayersAsync(
            string clubId,
            string positionId,
            string playerName,
            string order,
            int page = 1)
        {
            var model = new PlayersListingViewModel
            {
                Players = await this.players
                    .GetAllWithPaginationAsync<PlayerServiceModel>(clubId, positionId, playerName, order, page, PlayersListingPageSize),
                CurrentPage = page,
            };

            this.ViewBag.Action = nameof(GetPartialPlayersAsync);
            this.ViewBag.Controller = nameof(SquadController).ToFirstWord();

            return PartialView("_PartialPlayersPagination", model);
        }
    }
}

