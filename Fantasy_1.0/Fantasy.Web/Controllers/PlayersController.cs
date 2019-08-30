using Fantasy.Common;
using Fantasy.Data;
using Fantasy.Services;
using Fantasy.Services.Models;
using Fantasy.Web.Infrastructure.Extensions;
using Fantasy.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fantasy.Web.Controllers
{
    using static DataConstants;
    using static GlobalConstants;

    public class PlayersController : Controller
    {
        private readonly IFootballPlayerService players;

        public PlayersController(IFootballPlayerService players)
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

            var model = await this.players.GetByIdAsync<FootballPlayerDetailsServiceModel>(playerId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public async Task<IActionResult> GetPartialStatisticsAsync(int playerId, string position, int gameweekId = AllTimeStatisticsGameweekId)
        {


            switch (position)
            {
                case Goalkeeper:
                    return PartialView("_PartialGoalkeeperStatistics", 
                        await this.players.GetStatisticsAsync<GoalkeeperStatisticsServiceModel>(playerId, gameweekId));
                case Defender:
                    return PartialView("_PartialDefenderStatistics",
                        await this.players.GetStatisticsAsync<DefenderStatisticsServiceModel>(playerId, gameweekId));
                case Midfielder:
                    return PartialView("_PartialMidfielderStatistics", 
                        await this.players.GetStatisticsAsync<MidfielderStatisticsServiceModel>(playerId, gameweekId));
                case Forward:
                    return PartialView("_PartialForwardStatistics", 
                        await this.players.GetStatisticsAsync<ForwardStatisticsServiceModel>(playerId, gameweekId));
                default:
                    return BadRequest();
            }
        }
    }
}
