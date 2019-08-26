using System;
using System.Linq;
using System.Threading.Tasks;
using Fantasy.Data;
using Fantasy.Data.Models.Common;
using Fantasy.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fantasy.Web.ViewComponents
{
    public class TopTenFootballPlayersViewComponent : ViewComponent
    {
        private readonly FantasyDbContext db;
        private readonly UserManager<FantasyUser> userManager;

        public TopTenFootballPlayersViewComponent(FantasyDbContext db, UserManager<FantasyUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string position)
        {
              
           Console.WriteLine();

            var topTen = await this.db.FootballPlayers
                .Where(fp => fp.FootballPlayerPosition.Name == position)
                .Select(fp => new TopTenFootballPlayerViewModel
                {
                    Points = fp.GameweekPoints.Where(gwp => gwp.GameweekId != 40).Sum(gwp => gwp.Points),
                    Name = fp.Info.Name,
                    Id = fp.Id,
                    SmallImgUrl = fp.FootballClub.BadgeImgUrl,
                    Position = position,
                })
                .OrderBy(fp => -fp.Points)
                .Take(10)
                .ToListAsync();

            return this.View(topTen);
        }
    }
}
