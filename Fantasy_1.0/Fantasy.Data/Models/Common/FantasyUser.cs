using System.ComponentModel.DataAnnotations;
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

        public int FootballClubId { get; set; }
        public FootballClub FootballClub { get; set; }
    }
}
