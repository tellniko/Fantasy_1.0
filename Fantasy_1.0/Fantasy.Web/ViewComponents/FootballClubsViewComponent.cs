using Fantasy.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy.Web.ViewComponents
{
    public class FootballClubsViewComponent : ViewComponent
    {
        private readonly FantasyDbContext db;

        public FootballClubsViewComponent(FantasyDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool includeAll, bool useShortNames)
        {
            var clubs = await this.db.FootballClubs
                .OrderBy(fc => fc.Name)
                .Select(fc => new SelectListItem
                {
                    Text = useShortNames ? fc.ShortName : fc.Name,
                    Value = fc.Tag
                })
                .ToListAsync();

            if (includeAll)
            {
                clubs.Insert(0, new SelectListItem("All", string.Empty));
            }

            return this.View(clubs);
        }
    }
}
