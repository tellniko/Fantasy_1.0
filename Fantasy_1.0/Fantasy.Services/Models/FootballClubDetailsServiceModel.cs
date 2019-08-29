using System.Collections.Generic;
using Fantasy.Data.Models;

namespace Fantasy.Services.Models
{
    public class FootballClubDetailsServiceModel : FootballClubServiceModel
    {
        public byte Rating { get; set; }

        public string Tag { get; set; }

        public List<FootballPlayerServiceModel> Squad { get; set; } = new List<FootballPlayerServiceModel>();
    }
}
