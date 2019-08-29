using Fantasy.Data;
using Fantasy.Web.Infrastructure.Extensions;
using Fantasy.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy.Web.ViewComponents
{
    public class TopTenFootballPlayersViewComponent : ViewComponent
    {
        private readonly FantasyDbContext db;

        public TopTenFootballPlayersViewComponent(FantasyDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(string position)
        {
              
           Console.WriteLine();

            var topTen = await this.db.FootballPlayers
                .Where(fp => fp.Position.Name == position && fp.IsPlayable)
                .Select(fp => new TopTenFootballPlayerViewModel
                {
                    Points = fp.GameweekPoints.Where(gwp => gwp.GameweekId != 40).Sum(gwp => gwp.Points),
                    Name = fp.Info.Name.ToFuckinNormalName().PadLeft(30,' '),
                    Position = position,
                })
                .OrderBy(fp => -fp.Points)
                .Take(10)
                .ToListAsync();

            return this.View(topTen);
        }
    }
}
