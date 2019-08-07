using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.Players;

namespace Fantasy.Data.Models.Statistics
{
    public class GoalkeepingStatistics 
    {
        public ushort Saves { get; set; }

        public ushort PenaltiesSaved { get; set; }

        public ushort Punches { get; set; }

        public ushort HighClaims { get; set; }

        public ushort Catches { get; set; }

        public ushort SweeperClearances { get; set; }

        public ushort GoalKicks { get; set; }

        public int? PlayerId { get; set; }
        public Player Player { get; set; }

        public int FixtureId { get; set; }
        public Fixture Fixture { get; set; }
    }
}
