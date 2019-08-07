using System;
using Fantasy.Common.Mapping;
using Fantasy.Data.Models.Common;

namespace Fantasy.Services.Administrator.Models
{
    public class FixtureServiceModel : IMapTo<Fixture>
    {
        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public DateTime DateTimeStart { get; set; }

        public int GameweekId { get; set; }

        public bool Finished { get; set; }
    }
}
