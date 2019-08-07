using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Fantasy.Common.Mapping;
using Fantasy.Data.Models.Common;
using Fantasy.Services.Administrator.Models;

namespace Fantasy.Web.Areas.Administrator.Models
{
    public class GameWeekViewModel : IMapFrom<GameweekServiceModel>, IMapTo<GameweekServiceModel>
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public bool Finished { get; set; } = false;

        [DataType(DataType.Date)]
        public DateTime Start { get; set; }

        public string Name => $"{nameof(Gameweek)} {this.Number}";
    }
}
