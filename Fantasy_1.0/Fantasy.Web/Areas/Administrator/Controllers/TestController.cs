using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models;
using Fantasy.Services.Models;
using Fantasy.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Fantasy.Web.Areas.Administrator.Controllers
{
    [AllowAnonymous]
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
            Console.WriteLine("ola");

            var userId = this.userManager.GetUserId(User);


            Console.WriteLine();



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



    public class Test : IMapFrom<FootballPlayer>, IHaveCustomMappings
    {
        public decimal Sum { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<FootballPlayer, Test>()
                .ForMember(x => x.Sum, cfg => cfg.MapFrom(y => y.GameweekPoints.Sum(z => z.Points)));
        }
    }
}
