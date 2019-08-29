using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fantasy.Data.Models
{
    public class FootballPlayer : BaseModel<int>
    {
        public bool IsInjured { get; set; } = false;

        public bool IsPlayable { get; set; } = true;

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public FootballPlayerInfo Info { get; set; }

        public int FootballPlayerPositionId { get; set; }
        public FootballPlayerPosition Position { get; set; }

        public int FootballClubId { get; set; }
        public FootballClub FootballClub { get; set; }

        public List<GameweekStatistics> GameweekStatistics { get; set; } = new List<GameweekStatistics>();

        public List<FantasyPlayer> FantasyUserPlayers { get; set; } = new List<FantasyPlayer>();

        public List<GameweekPoints> GameweekPoints { get; set; } = new List<GameweekPoints>();
    }
}
