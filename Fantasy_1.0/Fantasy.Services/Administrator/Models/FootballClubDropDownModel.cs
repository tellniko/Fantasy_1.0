using Fantasy.Common.Mapping;
using Fantasy.Data.Models;

namespace Fantasy.Services.Administrator.Models
{
    public class FootballClubDropDownModel : IMapFrom<FootballClub>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
