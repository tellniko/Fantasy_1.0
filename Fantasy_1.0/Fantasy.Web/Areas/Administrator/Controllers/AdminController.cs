using Fantasy.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
