using System;
using AutoMapper;
using Fantasy.Common.Mapping;
using Fantasy.Data.Models;

namespace Fantasy.Services.Administrator.Models
{
    public class FixtureServiceModel : IMapTo<Fixture>, IMapFrom<Fixture>, IHaveCustomMappings
    {
        public int HomeTeamId { get; set; }
        public string HomeTeamName { get; set; }


        public int AwayTeamId { get; set; }
        public string AwayTeamName { get; set; }


        public DateTime? DateTimeStart { get; set; }

        public int GameweekId { get; set; }

        public bool Finished { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Fixture, FixtureServiceModel>()
                .ForMember(f => f.HomeTeamName, cfg => cfg.MapFrom(f => f.HomeTeam.Name))
                .ForMember(f => f.AwayTeamName, cfg => cfg.MapFrom(f => f.AwayTeam.Name));
        }
    }
}
