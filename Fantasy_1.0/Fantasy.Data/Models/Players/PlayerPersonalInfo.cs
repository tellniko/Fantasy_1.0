using System;
using System.ComponentModel.DataAnnotations;
using Fantasy.Data.Models.Common;

namespace Fantasy.Data.Models
{
    using static DataConstants;

    public class PlayerPersonalInfo : BaseModel<int>
    {
        [Required]
        [MinLength(CommonNameMinLength)]
        [MaxLength(CommonNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string FootballPlayerImageUrl { get; set; } = FootballPlayerDefaultImgUrl;

        public byte ShirtNum { get; set; }

        public byte Height { get; set; }

        public byte Weight { get; set; }

        public DateTime? JoinDate { get; set; }

        public DateTime? BirthDate { get; set; }

        [MinLength(CommonNameMinLength)]
        [MaxLength(CommonNameMaxLength)]
        public string BirthPlace { get; set; }

        //public int CountryId { get; set; }
        public string Country { get; set; }

        //public int BirthCountryId { get; set; }
        public string BirthCountry { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}