using Fantasy.Data;
using Fantasy.Services;
using Fantasy.Services.Models;
using Fantasy.Web.Infrastructure;
using Fantasy.Web.Infrastructure.Extensions;
using Fantasy.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Fantasy.Common;

namespace Fantasy.Web.Controllers
{
    using static GlobalConstants;

    public class PlayersController : Controller
    {
        private readonly IPlayerService players;

        public PlayersController(IPlayerService players, FantasyDbContext db)
        {
            this.players = players;
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
                    .GetAllWithPaginationAsync<PlayerServiceModel>(clubId, positionId, playerName, order, page, PlayersListingPageSize),
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

            return View(await this.players.GetByIdAsync<PlayerDetailsServiceModel>(playerId));
        }

        public async Task<IActionResult> GetPartialStatisticsAsync(int playerId, string position, int gameweekId = 1)
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
