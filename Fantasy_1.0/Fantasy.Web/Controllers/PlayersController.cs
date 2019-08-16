using System;
using Fantasy.Data;
using Fantasy.Services;
using Fantasy.Services.Models;
using Fantasy.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Fantasy.Web.Models;

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
            return View();
        }

        public async Task<IActionResult> GetPartialPlayers(string clubId, string positionId, string playerName, string order, int page = 1)
        {
            var model = new PlayersListingViewModel
            {
                Players = await this.players.GetAllAsync2<PlayerServiceModel>(clubId, positionId, playerName, order, page, PlayersListingPageSize),
                CurrentPage = page,
            };

            return PartialView("_PartialPlayersPagination", model);

            //return PartialView("_PartialPlayers", await this.players.GetAllAsync<PlayerServiceModel>(clubId, positionId, playerName, order));
        }

        public async Task<IActionResult> Details(int playerId)
        {
            return View(await this.players.GetByIdAsync<PlayerDetailsServiceModel>(playerId));
        }

        public async Task<IActionResult> GetPartialStatistics(int playerId, string position, int gameweekId = 1)
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
