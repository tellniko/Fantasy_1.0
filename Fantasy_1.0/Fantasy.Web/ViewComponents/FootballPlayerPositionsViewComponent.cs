using Fantasy.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy.Web.ViewComponents
{
    public class FootballPlayerPositionsViewComponent : ViewComponent
    {
        private readonly FantasyDbContext db;

        public FootballPlayerPositionsViewComponent(FantasyDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var positions = await this.db.FootballPlayerPositions
                .OrderBy(fc => fc.Name)
                .Select(fc => new SelectListItem
                {
                    Text = fc.Name,
                    Value = fc.Name
                })
                .ToListAsync();

            positions.Insert(0, new SelectListItem("All", string.Empty));

            return this.View(positions);
        }
    }
}

