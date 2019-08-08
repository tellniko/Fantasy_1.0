using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models.Players;

namespace Fantasy.Services.Administrator.Models.Db
{
    public class FootballPlayerJsonInfo : IMapTo<FootballPlayerInfo>
    {
        public string Name { get; set; }

        public string FootballPlayerImageUrl { get; set; } 

        public byte? ShirtNumber { get; set; }

        public byte? Height { get; set; }

        public byte? Weight { get; set; }

        public DateTime? JoinDate { get; set; }

        public DateTime? BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public string Country { get; set; }

        public int PlayerId { get; set; }
    }
}
