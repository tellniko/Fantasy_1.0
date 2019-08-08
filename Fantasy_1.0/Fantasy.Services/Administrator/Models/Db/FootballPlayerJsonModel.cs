using AutoMapper;
using Fantasy.Common.Mapping;
using Fantasy.Data.Models.Players;

namespace Fantasy.Services.Administrator.Models.Db
{
    public class FootballPlayerJsonModel : IMapTo<Player>, IMapFrom<Player>
    {
        public int Id { get; set; }

        public int FootballClubId { get; set; }

        public int PositionId { get; set; }
    }
}
