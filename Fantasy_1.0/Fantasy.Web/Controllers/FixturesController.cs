using System.Threading.Tasks;
using Fantasy.Services;
using Fantasy.Services.Models;
using Fantasy.Web.Models;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        public async Task<IActionResult> GetPartialFixtures(int gameweekId)
        {
            var model = await this.fixtures.GetByIdAsync<FixtureServiceModel>(gameweekId);

            return PartialView("_PartialGameweekFixtures", model);

            //return PartialView("_PartialPlayers", await this.players.GetAllAsync<PlayerServiceModel>(clubId, positionId, playerName, order));
        }
    }
}
