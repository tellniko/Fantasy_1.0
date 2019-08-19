using Fantasy.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy.Web.Areas.Administrator.Controllers
{

    [Area("Administrator")]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
