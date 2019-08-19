using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fantasy.Common;
using Fantasy.Data.Models.Game;
using Microsoft.AspNetCore.Identity;

namespace Fantasy.Data.Models.Common
{
    
    public class FantasyUser : IdentityUser<string>
    {
        [Required]
        [MinLength(DataConstants.CommonNameMinLength)]
        [MaxLength(DataConstants.CommonNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [MinLength(DataConstants.CommonNameMinLength)]
        [MaxLength(DataConstants.CommonNameMaxLength)]
        public string SquadName { get; set; }

        public decimal Budget { get; set; }

        public IEnumerable<FantasyUserSquad> Squads { get; set; } = new List<FantasyUserSquad>();

        public int FootballClubId { get; set; }
        public FootballClub FootballClub { get; set; }
    }
}
