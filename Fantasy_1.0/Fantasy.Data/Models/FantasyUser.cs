using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Fantasy.Data.Models
{

    public class FantasyUser : IdentityUser<string>
    {
        [Required]
        [MinLength(DataConstants.CommonNameMinLength)]
        [MaxLength(DataConstants.CommonNameMaxLength)]
        public string SquadName { get; set; }

        public List<FantasyPlayer> Squad { get; set; } = new List<FantasyPlayer>();

        public List<GameweekScore> GameweekScoreses { get; set; } = new List<GameweekScore>();
    }
}
