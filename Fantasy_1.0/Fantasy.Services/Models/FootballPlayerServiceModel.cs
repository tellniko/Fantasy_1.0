using System.Linq;
using AutoMapper;
using Fantasy.Common.Mapping;
using Fantasy.Data.Models;

namespace Fantasy.Services.Models
{
    public class FootballPlayerServiceModel : IMapFrom<FootballPlayer>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string InfoName { get; set; }

        public decimal Price { get; set; }

        public string PositionName { get; set; }

        public string InfoSmallImgUrl { get; set; }

        public string FootballClubBadgeImgUrl { get; set; }

        public int FootballClubId { get; set; }

        public byte? InfoShirtNumber { get; set; }

        public decimal Points { get; set; }

        public string InfoBigImgUrl { get; set; }

        public string FootballClubGround { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<FootballPlayer, FootballPlayerDetailsServiceModel>()
                .ForMember(p => p.FootballClubGround, cfg => cfg.MapFrom(p => p.FootballClub.Tag.ToLower() + ".jpg"));

            configuration
                .CreateMap<FootballPlayer, FootballPlayerServiceModel>()
                .ForMember(x => x.Points, cfg => cfg.MapFrom(y => y.GameweekPoints.Sum(z => z.Points)));
        }
    }
}