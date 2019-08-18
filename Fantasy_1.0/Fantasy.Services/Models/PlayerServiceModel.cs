using Fantasy.Common.Mapping;
using Fantasy.Data.Models.FootballPlayers;

namespace Fantasy.Services.Models
{
    public class PlayerServiceModel : IMapFrom<FootballPlayer>
    {
        public int Id { get; set; }

        public string InfoName { get; set; }

        public decimal Price { get; set; }

        public string FootballPlayerPositionName { get; set; }

        public string InfoSmallImgUrl { get; set; }

        public string FootballClubBadgeImgUrl { get; set; }
    }
}
