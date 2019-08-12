using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.FootballPlayers;
using Fantasy.Services;
using Fantasy.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Fantasy.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fantasy.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlayerService players;
        private readonly FantasyDbContext db;

        public HomeController(IPlayerService players, FantasyDbContext db)
        {
            this.players = players;
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

       
        //public IActionResult GetPartial(string clubId, string positionId)
        //{

        //    var players = this.players.GetAll(clubId, positionId);

        //    return PartialView("_PartialPlayers", players);
        //}



        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        private IEnumerable<SelectListItem> GetFootballClubs()
        {
            var clubs = this.db.FootballClubs
                .OrderBy(fc => fc.Id)
                .Select(fc => new SelectListItem
                {
                    Text = fc.Name,
                    Value = fc.Tag
                })
                .ToList();

            clubs.Insert(0, new SelectListItem("All", ""));

            return clubs;
        }

        private IEnumerable<SelectListItem> GetFootballPlayerPositions()
        {
            var positions = this.db.FootballPlayerPositions
                .OrderBy(p => p.Id)
                .Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Name,
                })
                .ToList();

            positions.Insert(0, new SelectListItem("All",""));

            return positions;
        }

    }
}
