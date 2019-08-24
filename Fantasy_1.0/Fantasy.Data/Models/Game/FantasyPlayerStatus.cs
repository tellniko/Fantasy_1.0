using System.Collections.Generic;
using Fantasy.Data.Models.Common;

namespace Fantasy.Data.Models.Game
{
    public class FantasyPlayerStatus : BaseModel<int>
    {
        public bool IsCaptain{ get; set; }

        public bool IsBenched { get; set; }

        public int FantasyPlayerId { get; set; }
        public FantasyPlayer FantasyPlayer { get; set; }

        public List<GameweekStatus> Statuses { get; set; } = new List<GameweekStatus>();
    }
}