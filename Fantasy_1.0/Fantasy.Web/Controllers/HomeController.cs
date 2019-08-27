using Fantasy.Data;
using Fantasy.Services;
using Fantasy.Web.Infrastructure.Extensions;
using Fantasy.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Club(string id)
        {
            this.TempData.AddSuccessMessage("Coming soon...");

            return View(new ClubViewModel{Img = id});
        }

       
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
