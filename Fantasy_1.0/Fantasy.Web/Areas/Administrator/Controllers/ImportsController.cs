using Fantasy.Data;
using Fantasy.Services.Administrator;
using Fantasy.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fantasy.Web.Areas.Administrator.Controllers
{
    public class ImportsController : AdminController
    {
        private readonly IImportService importService;
        private readonly FantasyDbContext db;

        public ImportsController(IImportService imports, FantasyDbContext db)
        {
            this.importService = imports;
            this.db = db;
        }

        public IActionResult ImportPlayers()
        {
            var result = this.importService.ImportPlayers();

            if (result == -1)
            {
                this.TempData.AddErrorMessage("The players have been imported already!");
            }
            else if (result == 0)
            {
                this.TempData.AddSuccessMessage($"There is a problem with the Json file or database IDENTITY_INSERT!");
            }
            else
            {
                this.TempData.AddSuccessMessage($"{result} players have been imported!");
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ImportStatistics()
        {
            var model = this.GetGameweeks();

            return View(model);
        }

        [HttpPost]
        public IActionResult ImportStatistics(int gameweekId)
        {
            Console.WriteLine();

            var result = this.importService.ImportStatistics(gameweekId);

            if (result == null)
            {
                this.TempData.AddErrorMessage("No changes have been made!");
            }
            else if (int.TryParse(result, out var number))
            {
                this.TempData.AddSuccessMessage($"{number} changes have been made!");
            }
            else
            {
                this.TempData.AddErrorMessage(result);
            }

            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> GetGameweeks()
        {
            return this.db.Gameweeks
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
