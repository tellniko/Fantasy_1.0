using Fantasy.Data;
using Fantasy.Services;
using Fantasy.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fantasy.Web.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService players;

        public PlayersController(IPlayerService players, FantasyDbContext db)
        {
            this.players = players;
        }

        public async Task<IActionResult> GetPartialPlayers(string clubId, string positionId)
        {
            return PartialView("_PartialPlayers", await this.players.GetAllAsync(clubId, positionId));
        }

        public async Task<IActionResult> Details(int playerId)
        {
            return View(await this.players.GetByIdAsync(playerId));
        }

        public async Task<IActionResult> GetPartialStatistics(int playerId, string position, int gameweekId = 1)
        {
            switch (position)
            {
                case "Goalkeeper":
                    return PartialView($"_Partial{position}Statistics",
                        await this.players.GetStatisticsAsync<GoalkeeperStatisticsServiceModel>(playerId, gameweekId));
                case "Defender":
                    return PartialView($"_Partial{position}Statistics",
                        await this.players.GetStatisticsAsync<GoalkeeperStatisticsServiceModel>(playerId, gameweekId));
                case "Midfielder":
                    return PartialView($"_Partial{position}Statistics",
                        await this.players.GetStatisticsAsync<GoalkeeperStatisticsServiceModel>(playerId, gameweekId));
                case "Forward":
                    return PartialView($"_Partial{position}Statistics",
                        await this.players.GetStatisticsAsync<GoalkeeperStatisticsServiceModel>(playerId, gameweekId));
                default:
                    return BadRequest();
            }
        }
    }
}
