using Fantasy.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Fantasy.Web.Infrastructure;
using Fantasy.Web.Infrastructure.Extensions;

namespace Fantasy.Web.ViewComponents
{

    using static SortingExtension;
    public class FootballPlayerPositionsViewComponent : ViewComponent
    {
        private readonly FantasyDbContext db;

        public FootballPlayerPositionsViewComponent(FantasyDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool includeAll)
        {
            var positions = await this.db.FootballPlayerPositions
                .OrderBy(fc => SortByPosition(fc.Name))
                .Select(fc => new SelectListItem
                {
                    Text = fc.Name,
                    Value = fc.Name
                })
                .ToListAsync();

            if (includeAll)
            {
                positions.Insert(0, new SelectListItem("All", string.Empty));
            }

            return this.View(positions);
        }
    }
}

