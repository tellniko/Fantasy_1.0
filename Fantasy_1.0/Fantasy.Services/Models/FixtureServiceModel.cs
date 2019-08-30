using Fantasy.Common.Mapping;
using Fantasy.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fantasy.Services.Models
{
    public class FixtureServiceModel : IMapFrom<Fixture>
    {
        [Range(0, byte.MaxValue)]
        public byte Home { get; set; }

        [Range(0, byte.MaxValue)]
        public byte Away { get; set; }

        public DateTime? DateTimeStart { get; set; }

        public bool Finished { get; set; }

        public string HomeTeamShortName { get; set; }

        public string HomeTeamBadgeImgUrl { get; set; }

        public string HomeTeamTag { get; set; }

        public string AwayTeamTag { get; set; }

        public string AwayTeamShortName { get; set; }

        public string AwayTeamBadgeImgUrl { get; set; }

        public int GameWeekId { get; set; }

        public string GameweekName { get; set; }
    }
}
