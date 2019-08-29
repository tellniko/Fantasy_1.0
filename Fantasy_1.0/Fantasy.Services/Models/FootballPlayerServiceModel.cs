using Fantasy.Common.Mapping;
using Fantasy.Data.Models;

namespace Fantasy.Services.Models
{
    public class FootballPlayerServiceModel : IMapFrom<FootballPlayer>
    {
        public int Id { get; set; }

        public string InfoName { get; set; }

        public decimal Price { get; set; }

        public string PositionName { get; set; }

        public string InfoSmallImgUrl { get; set; }

        public string InfoBigImgUrl { get; set; }

        public string FootballClubBadgeImgUrl { get; set; }

        public int FootballClubId { get; set; }

        public byte? InfoShirtNumber { get; set; }
    }
}
