using System;
using System.ComponentModel.DataAnnotations;

namespace Fantasy.Services.Models
{
    public class PlayerDetailsServiceModel : PlayerServiceModel
    {
        public bool IsInjured { get; set; }

        public string InfoBigImgUrl { get; set; } 

        public byte InfoShirtNumber { get; set; }

        public byte InfoHeight { get; set; }

        public byte InfoWeight { get; set; }

        public DateTime? InfoJoinDate { get; set; }

        public DateTime? InfoBirthDate { get; set; }

        public string InfoCountry { get; set; }

        public string FootballClubName { get; set; }
    }
}
