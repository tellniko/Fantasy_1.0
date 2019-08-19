using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fantasy.Common;

namespace Fantasy.Data.Models.FootballPlayers
{
    public class FootballPlayerPosition : BaseModel<int>
    {
        [Required]
        [MinLength(DataConstants.CommonNameMinLength)]
        [MaxLength(DataConstants.CommonNameMaxLength)]
        public string Name { get; set; }

        public ICollection<FootballPlayer> FootballPlayers { get; set; } = new List<FootballPlayer>();
    }
}