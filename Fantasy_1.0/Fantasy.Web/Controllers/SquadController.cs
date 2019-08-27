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
using System.Linq;
using System.Threading.Tasks;
using Fantasy.Data;
using Microsoft.EntityFrameworkCore;

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
        private readonly IPlayerService players;
        private readonly IFixtureService fixtures;
        private readonly IGameweekService gamweeks;

        //todo remove
        private readonly FantasyDbContext db;

        public SquadController(
            UserManager<FantasyUser> userManager, 
            ISquadService squad, 
            IPlayerService players, 
            IFixtureService fixtures, 
            IGameweekService gamweeks, FantasyDbContext db)
        {
            this.userManager = userManager;
            this.squad = squad;
            this.players = players;
            this.fixtures = fixtures;
            this.gamweeks = gamweeks;
            this.db = db;
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


        public IActionResult History()
        {

            this.ViewBag.Action = nameof(GetPartialSquad);
            this.ViewBag.Controller = nameof(SquadController).ToFirstWord();

            return View();
        }


        public async Task<IActionResult> GetPartialSquad(int gameweekId = 1)
        {

            var userId = this.userManager.GetUserId(User);


            var result = await this.db.FantasyPlayers
                .Where(fp =>
                    fp.FantasyUserId == userId &&
                    fp.GameweekStatuses.First(s => s.GameweekId == gameweekId).IsBenched == false)
                .Select(fp => new HistotyViewModel
                {
                    Name = fp.FootballPlayer.Info.Name,
                    Points = fp.FootballPlayer.GameweekPoints.First(p => p.GameweekId == gameweekId).Points,
                    ImgUrl = fp.FootballPlayer.Info.BigImgUrl,
                    Id = fp.Id,
                    Position = fp.FootballPlayer.FootballPlayerPosition.Name
                })
                .OrderBy(x => SortByPosition(x.Position))
                .ToListAsync();


            var id = this.userManager.GetUserId(User);

            this.ViewBag.UserId = this.userManager.GetUserId(User);


            return PartialView("_PartialSquad", result);
        }

        public async Task<IActionResult> Test()
        {
            var userId = this.userManager.GetUserId(User);

            await this.squad.Test(userId);

            return View();
        }


        public class HistotyViewModel //todo move
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string ImgUrl { get; set; }

            public decimal Points { get; set; }

            public string Position { get; set; }


        }
    }
}

