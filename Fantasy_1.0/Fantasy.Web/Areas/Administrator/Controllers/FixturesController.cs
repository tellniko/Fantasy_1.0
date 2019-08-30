using Fantasy.Common.Mapping;
using Fantasy.Services;
using Fantasy.Services.Administrator.Models;
using Fantasy.Web.Areas.Administrator.Models;
using Fantasy.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Fantasy.Web.Areas.Administrator.Controllers
{
    public class FixturesController : AdminController
    {
        private readonly IGameweekService gameweeks;
        private readonly IFootballClubService footballClubs;
        private readonly IFixtureService fixtures;

        public FixturesController(IGameweekService gameweeks, IFootballClubService footballClubs, IFixtureService fixtures)
        {
            this.gameweeks = gameweeks;
            this.footballClubs = footballClubs;
            this.fixtures = fixtures;
        }

        public async Task<IActionResult> Create()
        {
            
            var model = new FixtureFormModel
            {
                FootballClubs = await this.GetFootballClubs(),
                Gameweeks = this.GetGameweeks(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FixtureFormModel model)
        {
            if (!ModelState.IsValid || model.AwayTeamId == model.HomeTeamId)
            {
                model.FootballClubs = await this.GetFootballClubs();
                model.Gameweeks = this.GetGameweeks();
                this.TempData.AddErrorMessage("Error");
                return View(model);
            }

            var result = this.fixtures.Create(model.To<FixtureServiceModel>());
            if (result != null)
            {
                this.TempData.AddErrorMessage(result);
                return View(model);
            }

            this.TempData.AddSuccessMessage("Fixture added!");

            return RedirectToAction(nameof(Index));
        }

        private IEnumerable<SelectListItem> GetGameweeks()
        {
            return this.gameweeks
                .GetAll<GameweekServiceModel>()
                .Select(gw => new SelectListItem
                {
                    Text = gw.Name,
                    Value = gw.Id.ToString()
                })
                .ToList();
        }

        private async Task<IEnumerable<SelectListItem>> GetFootballClubs()
        {
            var clubs =  await this.footballClubs
                .GetAll< FootballClubDropDownModel>();
                
                return clubs.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
                .ToList();
        }
    }
}
