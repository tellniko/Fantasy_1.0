using System;
using System.Threading.Tasks;
using Fantasy.Data;
using Fantasy.Services;
using Fantasy.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy.Web.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService players;

        public PlayersController(IPlayerService players, FantasyDbContext db)
        {
            this.players = players;
        }

        public async Task<IActionResult> GetPartial(string clubId, string positionId)
        {
            return PartialView("_PartialPlayers", await this.players.GetAllAsync(clubId, positionId));
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await this.players.GetByIdAsync(id));
        }
    }
}
