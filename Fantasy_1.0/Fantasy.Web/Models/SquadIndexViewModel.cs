using System;
using System.Collections.Generic;
using Fantasy.Services.Models;

namespace Fantasy.Web.Models
{
    public class SquadIndexViewModel
    {
        public List<FantasyPlayerServiceModel> Squad { get; set; }

        public IEnumerable<FixtureServiceModel> Fixtures { get; set; }

        public DateTime GameweekStartDate { get; set; }
    }
}
