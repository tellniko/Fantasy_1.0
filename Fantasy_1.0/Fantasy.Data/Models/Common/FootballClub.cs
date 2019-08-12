using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fantasy.Data.Models.FootballPlayers;

namespace Fantasy.Data.Models.Common
{
    using static DataConstants;

    public class FootballClub : BaseModel<int>
    {
        public FootballClub(string name, string shortName, string tag)
        {
            this.Name = name;
            this.ShortName = shortName;
            this.Tag = tag;
        }

        [Required]
        [MinLength(CommonNameMinLength)]
        [MaxLength(CommonNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(CommonNameMinLength)]
        [MaxLength(CommonNameMaxLength)]
        public string ShortName { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Tag { get; set; }

        public byte Rating { get; set; }

        public FootballClubInfo Info { get; set; }

        public IEnumerable<FootballPlayer> Squad { get; set; } = new List<FootballPlayer>();

        public IEnumerable<Fixture> HomeGames { get; set; } = new List<Fixture>();

        public IEnumerable<Fixture> AwayGames { get; set; } = new List<Fixture>();
    }
}