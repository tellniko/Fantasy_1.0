using Fantasy.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Fantasy.Common;
using Fantasy.Web.Infrastructure;

namespace Fantasy.Web.ViewComponents
{
    using static DataConstants;

    public class GameweeksViewComponent : ViewComponent
    {
        private readonly FantasyDbContext db;

        public GameweeksViewComponent(FantasyDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool all)
        {
            var gameweeks = await this.db.GameWeeks
                .Where(gw => gw.Id  != PreSeasonStatisticsGameweekId && gw.Id != AllTimeStatisticsGameweekId)
                .OrderBy(gw => gw.Id)
                .Select(gw => new SelectListItem
                {
                    Text = gw.Name,
                    Value = gw.Id.ToString()
                })
                .ToListAsync();

            if (all)
            {
                gameweeks.Insert(0, new SelectListItem("All Time", AllTimeStatisticsGameweekId.ToString()));

            }

            return this.View(gameweeks);
        }
    }
}