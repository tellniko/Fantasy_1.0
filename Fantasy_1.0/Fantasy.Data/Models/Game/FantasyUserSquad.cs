using System.Collections.Generic;
using Fantasy.Data.Models.Common;

namespace Fantasy.Data.Models.Game
{
    public class FantasyUserSquad : BaseModel<int>
    {
        public short Transfers { get; set; }

        public string UserId { get; set; }
        public FantasyUser User { get; set; }

        public int GameweekId { get; set; }
        public Gameweek Gameweek { get; set; }

        public IEnumerable<FantasyUserPlayer> Squad { get; set; } = new List<FantasyUserPlayer>();
    }
}
