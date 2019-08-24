using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fantasy.Common.Mapping;
using Fantasy.Data.Models.Common;

namespace Fantasy.Services.Administrator.Models
{
    public class GameweekServiceModel : IMapFrom<Gameweek>, IMapTo<Gameweek>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Finished { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
    }
}
