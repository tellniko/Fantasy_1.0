using Fantasy.Common.Mapping;
using System;
using Fantasy.Data.Models;

namespace Fantasy.Services.Administrator.Models.Db
{
    public class FootballPlayerInfoJsonModel : IMapFrom<FootballPlayerInfo>, IMapTo<FootballPlayerInfo>
    {
        public string Name { get; set; }

        public string BigImgUrl { get; set; } 

        public string SmallImgUrl { get; set; } 

        public byte? ShirtNumber { get; set; }

        public byte? Height { get; set; }

        public byte? Weight { get; set; }

        public DateTime? JoinDate { get; set; }

        public DateTime? BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public string Country { get; set; }

        public int FootballPlayerId { get; set; }
    }
}
