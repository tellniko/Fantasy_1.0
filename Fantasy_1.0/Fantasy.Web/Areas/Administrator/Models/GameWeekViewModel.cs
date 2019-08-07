using Fantasy.Common.Mapping;
using Fantasy.Data.Models.Common;
using Fantasy.Services.Administrator.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fantasy.Web.Areas.Administrator.Models
{
    public class GameWeekViewModel : IMapFrom<GameweekServiceModel>, IMapTo<GameweekServiceModel>
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public bool Finished { get; set; } = false;

        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        //public int SeasonId { get; set; }

        public string Name { get; set; }
    }
}
