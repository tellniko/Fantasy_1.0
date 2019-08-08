using Fantasy.Services.Administrator;
using Fantasy.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy.Web.Areas.Administrator.Controllers
{
    public class DatabaseController : AdministratorController
    {
        private readonly IDatabaseService database;

        public DatabaseController(IDatabaseService database)
        {
            this.database = database;
        }

        public IActionResult SeedPlayers()
        {
            var result = this.database.SeedPlayers();

            this.TempData.AddSuccessMessage(result);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult SeedStatistics()
        {
            var result = this.database.SeedStatistics();

            this.TempData.AddSuccessMessage(result);

            return RedirectToAction(nameof(Index));
        }
    }
}
