using System.Collections.Generic;
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

        public async Task<IViewComponentResult> InvokeAsync(string page2)
        {
            var clubs = await this.db.FootballClubs
                .OrderBy(fc => fc.Name)
                .Select(fc => new SelectListItem
                {
                    Text = fc.Name,
                    Value = fc.Tag
                })
                .ToListAsync();

            clubs.Insert(0, new SelectListItem("All", string.Empty));

            return this.View(clubs);
        }
    }
   
}
