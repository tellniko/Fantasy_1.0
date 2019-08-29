using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fantasy.Data.Models
{
    public class FootballClub : BaseModel<int>
    {
        [Required]
        [MinLength(DataConstants.CommonNameMinLength)]
        [MaxLength(DataConstants.CommonNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(DataConstants.CommonNameMinLength)]
        [MaxLength(DataConstants.CommonNameMaxLength)]
        public string ShortName { get; set; }

        [Required]
        [RegularExpression("^[A-Z]{3}$")]
        public string Tag { get; set; }

        public bool Playable { get; set; } = true;

        [Range(1, 5)]
        public byte Rating { get; set; } 

        public string BadgeImgUrl { get; set; }

        public List<FootballPlayer> Squad { get; set; } = new List<FootballPlayer>();

        public List<Fixture> HomeGames { get; set; } = new List<Fixture>();

        public List<Fixture> AwayGames { get; set; } = new List<Fixture>();
    }
}