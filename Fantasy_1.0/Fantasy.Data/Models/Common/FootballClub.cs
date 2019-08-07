using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fantasy.Data.Models.Players;

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

        //[Required]
        public string StadiumImgUrl { get; set; }

        public bool Playable { get; set; } = true;

        //[Required]
        //[MinLength(CommonNameMinLength)]
        //[MaxLength(CommonNameMaxLength)]
        public string ManagerName { get; set; }

        public string Ground { get; set; }

        public string PrimaryKitColor { get; set; }

        public string SecondaryKitColor { get; set; }

        public IEnumerable<Player> Squad { get; set; } = new List<Player>();

        public ICollection<Fixture> HomeGames { get; set; } = new List<Fixture>();

        public ICollection<Fixture> AwayGames { get; set; } = new List<Fixture>();
    }
}