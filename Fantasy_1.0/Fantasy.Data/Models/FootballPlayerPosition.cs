using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fantasy.Data.Models
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