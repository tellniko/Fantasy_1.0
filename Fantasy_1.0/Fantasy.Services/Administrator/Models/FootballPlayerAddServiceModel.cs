using System;
using System.ComponentModel.DataAnnotations;
using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models.FootballPlayers;

namespace Fantasy.Services.Administrator.Models
{
    public class FootballPlayerAddServiceModel : IMapFrom<FootballPlayer>, IMapTo<FootballPlayer>
    {
        public int Id { get; set; }

        public bool IsInjured { get; set; } = false;

        public bool IsPlayable { get; set; } = true;

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public int FootballPlayerPositionId { get; set; }

        public int FootballClubId { get; set; }

        public string InfoName { get; set; }

        [Required]
        public string InfoBigImgUrl { get; set; }

        [Required]
        public string InfoSmallImgUrl { get; set; }

        [Range(byte.MinValue, byte.MaxValue)]
        public byte? InfoShirtNumber { get; set; }

        [Range(byte.MinValue, byte.MaxValue)]
        public byte? InfoHeight { get; set; }

        [Range(byte.MinValue, byte.MaxValue)]
        public byte? InfoWeight { get; set; }

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
