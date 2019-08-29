using AutoMapper;
using Fantasy.Common.Mapping;
using Fantasy.Data.Models;

namespace Fantasy.Services.Administrator.Models.Db
{
    public class FootballPlayerJsonModel : IMapTo<FootballPlayer>, IMapFrom<FootballPlayer>
    {
        public int Id { get; set; }

        public int FootballClubId { get; set; }

        public int FootballPlayerPositionId { get; set; }

        public decimal Price { get; set; }

        public bool IsPlayable { get; set; }

        public bool IsInjured { get; set; }
    }
}
