using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.Players;

namespace Fantasy.Data.Models.Statistics
{
    public class AttackStatistics 
    {
        public short Goals { get; set; }

        public short PenaltiesScored { get; set; }

        public short FreeKicksScored { get; set; }

        public short Shots { get; set; }

        public short ShotsOnTarget { get; set; }

        public short HitWoodwork { get; set; }

        public short BigChancesMissed { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int FixtureId { get; set; }
        public Fixture Fixture { get; set; }
    }
}
