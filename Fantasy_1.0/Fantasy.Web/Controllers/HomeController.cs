using Fantasy.Services.Implementations;
using Fantasy.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fantasy.Services;

namespace Fantasy.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFootballClubService clubs;

        public HomeController(IFootballClubService clubs)
        {
            this.clubs = clubs;
        }

        public async Task<IActionResult> Index()
        {
            var model = await this.clubs.GetAll<FootballClubServiceModel>();

            return View(model);
        }

        public IActionResult Club(int id)
        {
            var club = this.clubs.GetDetails(id);
            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        public IActionResult Rules()
        {
            var model = new List<object>
            {
                new GoalkeeperStatisticsServiceModel(),
                new DefenderStatisticsServiceModel(),
                new MidfielderStatisticsServiceModel(),
                new ForwardStatisticsServiceModel(),
            };

            return View(model);
        }

       
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
