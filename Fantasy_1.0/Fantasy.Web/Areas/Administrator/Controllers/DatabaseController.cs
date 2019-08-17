using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            this.TempData.AddSuccessMessage(this.database.SeedPlayers());
            return RedirectToAction(nameof(Index));
        }

        public IActionResult SeedStatistics()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
