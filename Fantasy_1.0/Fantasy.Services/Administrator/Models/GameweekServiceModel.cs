using Fantasy.Common.Mapping;
using Fantasy.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

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
