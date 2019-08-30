using AutoMapper;
using Fantasy.Common.Mapping;
using Fantasy.Data.Models;
using System;

namespace Fantasy.Services.Models
{
    public class FootballPlayerDetailsServiceModel : FootballPlayerServiceModel, IHaveCustomMappings
    {
        public bool IsInjured { get; set; }

        public byte? InfoHeight { get; set; }

        public byte? InfoWeight { get; set; }

        public DateTime? InfoJoinDate { get; set; }

        public DateTime? InfoBirthDate { get; set; }

        public string InfoCountry { get; set; }

        public string Ground { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<FootballPlayer, FootballPlayerDetailsServiceModel>()
                .ForMember(p => p.Ground, cfg => cfg.MapFrom(p => p.FootballClub.Tag.ToLower() + ".jpg"));
        }
    }
}
