using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.Players;

namespace Fantasy.Data.Models.Statistics
{
    public class GoalkeepingStatistics 
    {
        public short Saves { get; set; }

        public short PenaltiesSaved { get; set; }

        public short Punches { get; set; }

        public short HighClaims { get; set; }

        public short Catches { get; set; }

        public short SweeperClearances { get; set; }

        public short GoalKicks { get; set; }

        public int? PlayerId { get; set; }
        public Player Player { get; set; }

        public int FixtureId { get; set; }
        public Fixture Fixture { get; set; }
    }
}
