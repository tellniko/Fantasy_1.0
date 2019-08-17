using Fantasy.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy.Web.ViewComponents
{
    public class GameweeksViewComponent : ViewComponent
    {
        private readonly FantasyDbContext db;

        public GameweeksViewComponent(FantasyDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var gameweeks = await this.db.GameWeeks
                .OrderBy(gw => gw.Id)
                .Skip(1)
                .OrderBy(gw => gw.Number)
                .Select(gw => new SelectListItem
                {
                    Text = "Gameweek " + gw.Number,
                    Value = gw.Id.ToString()
                })
                .ToListAsync();

            gameweeks.Insert(0, new SelectListItem("All Time", "1"));

            return this.View(gameweeks);
        }
    }
}