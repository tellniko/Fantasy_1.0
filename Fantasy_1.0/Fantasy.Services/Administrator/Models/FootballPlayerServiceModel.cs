using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models.FootballPlayers;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fantasy.Services.Administrator.Models
{
    public class FootballPlayerServiceModel : IMapFrom<FootballPlayer>, IMapTo<FootballPlayer>
    {
        public int Id { get; set; }

        public bool IsInjured { get; set; } = false;

        public bool IsPlayable { get; set; } = true;

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public string FootballPlayerPositionName { get; set; }

        public string FootballClubName { get; set; }

        public int FootballClubId { get; set; }

        public string InfoName { get; set; }

        [Required]
        public string InfoBigImgUrl { get; set; }

        [Required]
        public string InfoSmallImgUrl { get; set; }

        [Range(byte.MinValue, byte.MaxValue)]
        public byte InfoShirtNumber { get; set; }

        [Range(byte.MinValue, byte.MaxValue)]
        public byte InfoHeight { get; set; }

        [Range(byte.MinValue, byte.MaxValue)]
        public byte InfoWeight { get; set; }

        [DataType(DataType.Date)] //todo validation
        public DateTime? InfoJoinDate { get; set; }
       
        [DataType(DataType.Date)] //todo validation
        public DateTime? InfoBirthDate { get; set; }

        [MinLength(DataConstants.CommonNameMinLength)]
        [MaxLength(DataConstants.CommonNameMaxLength)]
        public string InfoBirthPlace { get; set; }

        [MinLength(DataConstants.CommonNameMinLength)]
        [MaxLength(DataConstants.CommonNameMaxLength)]
        public string InfoCountry { get; set; }
    }
}
