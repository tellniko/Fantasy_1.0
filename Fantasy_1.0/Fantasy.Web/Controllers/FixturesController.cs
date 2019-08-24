using Fantasy.Services;
using Fantasy.Services.Models;
using Fantasy.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fantasy.Web.Controllers
{
    public class FixturesController : Controller
    {
        private readonly IFixtureService fixtures;

        public FixturesController(IFixtureService fixtures)
        {
            this.fixtures = fixtures;
        }

        public IActionResult Index()
        {
            this.ViewBag.Action = nameof(GetPartialFixturesAsync);
            this.ViewBag.Controller = nameof(FixturesController).ToFirstWord();

            return View();
        }

        public async Task<IActionResult> GetPartialFixturesAsync(int gameweekId)
        {
            var model = await this.fixtures.GetByIdAsync<FixtureServiceModel>(gameweekId);

            return PartialView("_PartialGameweekFixtures", model);

            //return PartialView("_PartialPlayers", await this.players.GetAllAsync<PlayerServiceModel>(clubId, positionId, playerName, order));
        }
    }
}
