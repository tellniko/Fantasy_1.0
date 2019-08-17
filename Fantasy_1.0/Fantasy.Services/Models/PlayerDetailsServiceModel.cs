using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Fantasy.Common.Mapping;
using Fantasy.Data.Models.FootballPlayers;

namespace Fantasy.Services.Models
{
    public class PlayerDetailsServiceModel : PlayerServiceModel, IHaveCustomMappings
    {
        public bool IsInjured { get; set; }

        public string InfoBigImgUrl { get; set; } 

        public byte? InfoShirtNumber { get; set; }

        public byte? InfoHeight { get; set; }

        public byte? InfoWeight { get; set; }

        public DateTime? InfoJoinDate { get; set; }

        public DateTime? InfoBirthDate { get; set; }

        public string InfoCountry { get; set; }

        public string FootballClubGroundImg { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<FootballPlayer, PlayerDetailsServiceModel>()
                .ForMember(p => p.FootballClubGroundImg, cfg => cfg.MapFrom(p => p.FootballClub.Info.StadiumImgUrl));
        }
    }
}
