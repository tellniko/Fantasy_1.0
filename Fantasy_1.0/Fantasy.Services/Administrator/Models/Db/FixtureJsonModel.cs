using System;
using Fantasy.Common.Mapping;
using Fantasy.Data.Models;

namespace Fantasy.Services.Administrator.Models.Db
{
    public class FixtureJsonModel : IMapTo<Fixture>, IMapFrom<Fixture>
    {
        public DateTime? DateTimeStart { get; set; }

        public bool Finished { get; set; }

        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public int GameWeekId { get; set; }
    }
}
