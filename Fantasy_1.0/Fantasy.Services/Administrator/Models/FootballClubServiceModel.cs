using Fantasy.Common.Mapping;
using Fantasy.Data.Models.Common;

namespace Fantasy.Services.Administrator.Models
{
    public class FootballClubServiceModel : IMapFrom<FootballClub>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
