using System;
using System.Linq;
using System.Threading.Tasks;
using Fantasy.Common;
using Fantasy.Data;
using Fantasy.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fantasy.Web.Areas.Administrator.Controllers
{
    using static GlobalConstants;

    [Area(AdministratorRole)]
    [Authorize(Roles = AdministratorRole)]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
