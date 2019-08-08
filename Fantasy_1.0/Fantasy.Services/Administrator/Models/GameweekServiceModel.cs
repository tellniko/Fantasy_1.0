using System;
using System.Collections.Generic;
using AutoMapper;
using Fantasy.Common.Mapping;
using Fantasy.Data.Models.Common;

namespace Fantasy.Services.Administrator.Models
{
    public class GameweekServiceModel : IMapFrom<Gameweek>, IMapTo<Gameweek>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public byte Number { get; set; }

        public bool Finished { get; set; } = false;

        public DateTime Start { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Gameweek, GameweekServiceModel>()
                .ForMember(gw => gw.Name, cfg => cfg.MapFrom(gw => $"{nameof(Gameweek)} {gw.Number}"));
        }
    }
}