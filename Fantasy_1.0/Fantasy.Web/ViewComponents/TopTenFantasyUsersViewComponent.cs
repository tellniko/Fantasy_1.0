using Fantasy.Data;
using Fantasy.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy.Web.ViewComponents
{
    public class TopTenFantasyUsersViewComponent : ViewComponent
    {
        private readonly FantasyDbContext db;

        public TopTenFantasyUsersViewComponent(FantasyDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var topTen = await this.db.Users
                .Where(u => u.UserName != "admin")
                .Select(u => new TopTenUserViewModel
                {
                    Name = u.UserName,
                    Squad = u.SquadName,
                    Points = u.GameweekScoreses.Sum(x => x.Score)
                })
                .OrderByDescending(u => u.Points)
                .Take(10)
                .ToListAsync();

            return this.View(topTen);
        }
    }
}
