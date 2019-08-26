using Fantasy.Common;
using Fantasy.Data;
using Fantasy.Data.Models.Common;
using Fantasy.Services;
using Fantasy.Services.Models;
using Fantasy.Web.Infrastructure.Extensions;
using Fantasy.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fantasy.Web.Controllers
{
    using static GlobalConstants;

    public class PlayersController : Controller
    {
        private readonly IPlayerService players;
        //todo remove
        private readonly FantasyDbContext db;
        private readonly UserManager<FantasyUser> userManager;

        public PlayersController(IPlayerService players, FantasyDbContext db)
        {
            this.players = players;
            this.db = db;
        }

        public IActionResult Index()
        {
            this.ViewBag.Action = nameof(GetPartialPlayersAsync);
            this.ViewBag.Controller = nameof(PlayersController).ToFirstWord();

            return View();
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
                    .GetAllWithPaginationAsync<FootballPlayerServiceModel>(clubId, positionId, playerName, order, page, PlayersListingPageSize),
                CurrentPage = page,
            };

            this.ViewBag.Action = nameof(GetPartialPlayersAsync);
            this.ViewBag.Controller = nameof(PlayersController).ToFirstWord();

            return PartialView("_PartialPlayersPagination", model);
        }

        public async Task<IActionResult> Details(int playerId)
        {
            this.ViewBag.Action = nameof(GetPartialStatisticsAsync);
            this.ViewBag.Controller = nameof(PlayersController).ToFirstWord();

            return View(await this.players.GetByIdAsync<FootballPlayerDetailsServiceModel>(playerId));
        }

        public async Task<IActionResult> GetPartialStatisticsAsync(int playerId, string position, int gameweekId = 40)//todo check
        {
          switch (position)
            {
                case Goalkeeper:
                    return PartialView("_PartialStatistics", 
                        await this.players.GetStatisticsAsync<GoalkeeperStatisticsServiceModel>(playerId, gameweekId));
                case Defender:
                    return PartialView("_PartialStatistics",
                        await this.players.GetStatisticsAsync<DefenderStatisticsServiceModel>(playerId, gameweekId));
                case Midfielder:
                    return PartialView("_PartialStatistics", 
                        await this.players.GetStatisticsAsync<MidfielderStatisticsServiceModel>(playerId, gameweekId));
                case Forward:
                    return PartialView("_PartialStatistics", 
                        await this.players.GetStatisticsAsync<ForwardStatisticsServiceModel>(playerId, gameweekId));
                default:
                    return BadRequest();
            }
        }
    }
}
