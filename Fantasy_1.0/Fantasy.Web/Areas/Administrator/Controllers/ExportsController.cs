using Fantasy.Data;
using Fantasy.Services.Administrator;
using Fantasy.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Fantasy.Web.Areas.Administrator.Controllers
{
    public class ExportsController : HomeController
    {
        private readonly IExportServices exportServices;
        private readonly FantasyDbContext db;

        public ExportsController(IExportServices exportServices, FantasyDbContext db)
        {
            this.exportServices = exportServices;
            this.db = db;
        }

        public IActionResult ExportPlayersJson()
        {
            this.exportServices.ExportFootballPlayers();

            this.TempData.AddSuccessMessage("File created!");

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ExportPlayerInfosJson()
        {
            this.exportServices.ExportFootballPlayerInfos();

            this.TempData.AddSuccessMessage("File created!");

            this.TempData.AddErrorMessage("Disabled!");


            return RedirectToAction(nameof(Index));
        }


        public IActionResult ExportStatisticsJson()
        {
            var model = this.GetGameweeks();
            return View(model);
        }

        [HttpPost]
        public IActionResult ExportStatisticsJson(int gameweekId)
        {
            //this.TempData.AddErrorMessage("Disabled!");
            //return RedirectToAction(nameof(Index));

            var result = this.exportServices.ExportStatistics(gameweekId);

            if (result == 0)
            {
                return BadRequest();
            }

            if (result == -1)
            {
                this.TempData.AddErrorMessage("Files were not been exported!");
            }
            else
            {
                this.TempData.AddSuccessMessage("Files were been exported successfully!");
            }

            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> GetGameweeks()
        {
            return this.db.GameWeeks
                .OrderBy(x => x.Id)
                .Select(gw => new SelectListItem
                {
                    Text = gw.Name,
                    Value = gw.Id.ToString()
                })
                .ToList();
        }
    }
}
