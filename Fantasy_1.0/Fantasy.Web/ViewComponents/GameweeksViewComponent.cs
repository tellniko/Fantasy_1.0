using System;
using Fantasy.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Fantasy.Data.Models;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

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

        public async Task<IViewComponentResult> InvokeAsync(bool includeAll, bool finished, bool includeStart)
        {

            var gameweeks = await this.db.Gameweeks
                .Where(gw =>
                    gw.Id != PreSeasonStatisticsGameweekId && gw.Id != AllTimeStatisticsGameweekId) 
                .OrderBy(gw => gw.Id)
                .ToListAsync();

            if (finished)
            {
                gameweeks = gameweeks.Where(gw => gw.Finished).ToList();
            }


            var result = gameweeks
                .Select(gw => new SelectListItem
                {
                    Text = includeStart ? gw.Name + " - Starts at " + gw.Start.ToString("D") : gw.Name,
                    Value = gw.Id.ToString()
                })
                .ToList();

            if (includeAll)
            {
                result.Insert(0, new SelectListItem("All Time", AllTimeStatisticsGameweekId.ToString()));
            }

            return this.View(result);
        }
    }
}