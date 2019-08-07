using System.Collections.Generic;
using Fantasy.Services.Administrator.Models;

namespace Fantasy.Web.Areas.Administrator.Models
{
    public class GameWeekDetailsViewModel
    {
        public GameweekServiceModel Gameweek { get; set; }

        public IEnumerable<FixtureServiceModel> Fixtures { get; set; }
    }
}
