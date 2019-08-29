using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fantasy.Data;
using Fantasy.Data.Models;
using Fantasy.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Fantasy.Web.Areas.Administrator.Controllers
{
    public class TestController : AdminController
    {
        private readonly FantasyDbContext db;
        private readonly UserManager<FantasyUser> userManager;

        public TestController(UserManager<FantasyUser> userManager, FantasyDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public async Task<IActionResult> Test()
        {
            var gw = new GameweekStatistics
            {
                GameweekId = 39,
                PlayerId = 4852,
                CleanSheets = 35,
                GoalsConceded = 170,
                YellowCards = 9,
                RedCards = 2,
                Fouls = 5,
                Saves = 443,
                PenaltiesScored = 5,
                Punches = 51,
                HighClaims = 145,
                Catches = 52,
                SweeperClearances = 101,
                GoalKicks = 1197,
                Appearances = 128,
                Wins = 48,
                Losses = 44,
                Passes = 3210,
                AccurateLongBalls = 1047
                };

             this.db.GameweekStatistics.Add(gw);
             var result = this.db.SaveChanges();
             this.TempData.AddSuccessMessage(result.ToString());


            //var gameweek = await this.db.Gameweeks.FirstOrDefaultAsync(gw => gw.Id == gameweekId);
            //var user = await this.userManager.FindByIdAsync(userId);

            //Console.WriteLine();

            //var test = this.db.FantasyPlayers
            //    .Where(p => p.FantasyUser == user)
            //    .SelectMany(p => p.FootballPlayer.GameweekPoints.Where(gwp => gwp.Gameweek == gameweek))
            //    .Select(x => new
            //    {
            //        id = x.FootbalPlayerId,
            //        points = x.Points,
            //        gameweekId = x.GameweekId,
            //        fantasyplayerId = x.FootballPlayer.FantasyUserPlayers.Find(z => z.FootballPlayerId == x.FootbalPlayerId).Id

            //    })
            //    .ToList();

            //Console.WriteLine();

            //var mySquad = this.db.FantasyPlayers
            //    .Where(x => x.FantasyUser == user &&
            //                x.GameweekStatuses.First(y => y.Gameweek == gameweek).IsBenched == false)

            //    .Sum(z => z.FootballPlayer.GameweekPoints.First(y => y.Gameweek == gameweek).Points);

            return Redirect(nameof(Index));
        }
    }
}
