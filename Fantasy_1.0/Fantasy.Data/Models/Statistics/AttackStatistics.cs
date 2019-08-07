using Fantasy.Data.Models.Common;

namespace Fantasy.Data.Models.Statistics
{
    public class AttackStatistics 
    {
        public ushort Goals { get; set; }

        public ushort PenaltiesScored { get; set; }

        public ushort FreeKicksScored { get; set; }

        public ushort Shots { get; set; }

        public ushort ShotsOnTarget { get; set; }

        public ushort HitWoodwork { get; set; }

        public ushort BigChancesMissed { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int FixtureId { get; set; }
        public Fixture Fixture { get; set; }
    }
}
