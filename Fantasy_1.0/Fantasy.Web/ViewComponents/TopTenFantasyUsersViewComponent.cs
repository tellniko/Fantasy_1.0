using System;
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
                .Take(5)
                .ToListAsync();


            var count = topTen.Count;

            if (count != 5)
            {
                for (int i = 0; i < 5 - count; i++)
                {
                    Console.WriteLine(i);

                    topTen.Add(new TopTenUserViewModel
                    {
                        Name = "N/A",
                        Squad = "N/A",
                        Points = 0,
                    });
                }
            }



            return this.View(topTen);
        }
    }
}
