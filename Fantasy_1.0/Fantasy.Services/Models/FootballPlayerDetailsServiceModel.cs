using AutoMapper;
using Fantasy.Common.Mapping;
using Fantasy.Data.Models;
using System;

namespace Fantasy.Services.Models
{
    public class FootballPlayerDetailsServiceModel : FootballPlayerServiceModel
    {
        public bool IsInjured { get; set; }

        public byte? InfoHeight { get; set; }

        public byte? InfoWeight { get; set; }

        public DateTime? InfoJoinDate { get; set; }

        public DateTime? InfoBirthDate { get; set; }

        public string InfoCountry { get; set; }
    }
}
