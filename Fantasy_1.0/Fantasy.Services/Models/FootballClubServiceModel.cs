using Fantasy.Common.Mapping;
using Fantasy.Data.Models;

namespace Fantasy.Services.Models
{
    public class FootballClubServiceModel : IMapFrom<FootballClub>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string BadgeImgUrl { get; set; }
    }
}
