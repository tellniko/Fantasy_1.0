using System;
using System.ComponentModel.DataAnnotations;

namespace Fantasy.Data.Models.FootballPlayers
{
    public class FootballPlayerInfo : BaseModel<int>
    {
        [Required]
        [MinLength(DataConstants.CommonNameMinLength)]
        [MaxLength(DataConstants.CommonNameMaxLength)]
        public string Name { get; set; }

        public string BigImgUrl { get; set; } = DataConstants.FootballPlayerDefaultImgUrl;

        public string SmallImgUrl { get; set; } = DataConstants.FootballPlayerDefaultImgUrl;

        [Range(byte.MinValue, byte.MaxValue)]
        public byte? ShirtNumber { get; set; }

        [Range(byte.MinValue, byte.MaxValue)]
        public byte? Height { get; set; }

        [Range(byte.MinValue, byte.MaxValue)]
        public byte? Weight { get; set; }

        public DateTime? JoinDate { get; set; }

        public DateTime? BirthDate { get; set; }

        [MinLength(DataConstants.CommonNameMinLength)]
        [MaxLength(DataConstants.CommonNameMaxLength)]
        public string BirthPlace { get; set; }

        [MinLength(DataConstants.CommonNameMinLength)]
        [MaxLength(DataConstants.CommonNameMaxLength)]
        public string Country { get; set; }

        public int FootballPlayerId { get; set; }
        public FootballPlayer FootballPlayer { get; set; }
    }
}