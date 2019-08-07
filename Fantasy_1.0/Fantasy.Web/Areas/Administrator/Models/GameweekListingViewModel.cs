using Fantasy.Services.Administrator.Models;
using System.Collections.Generic;

namespace Fantasy.Web.Areas.Administrator.Models
{
    public class GameweekListingViewModel
    {
        public IEnumerable<GameWeekViewModel> Gameweeks { get; set; }
    }
}
