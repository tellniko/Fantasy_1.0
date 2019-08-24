using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.FootballPlayers;
using System.Collections.Generic;

namespace Fantasy.Data.Models.Game
{
    public class FantasyPlayer : BaseModel<int>
    {
        public int FootballPlayerId { get; set; }
        public FootballPlayer FootballPlayer { get; set; }

        public string FantasyUserId { get; set; }
        public FantasyUser FantasyUser { get; set; }

        public List<GameweekStatus> GameweekStatuses { get; set; } = new List<GameweekStatus>();
    }
}
