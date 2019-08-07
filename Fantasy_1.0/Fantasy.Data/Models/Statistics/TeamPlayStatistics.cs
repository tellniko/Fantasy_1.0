using Fantasy.Data.Models.Common;

namespace Fantasy.Data.Models.Statistics
{
    public class TeamPlayStatistics 
    {
        public ushort Assists { get; set; }

        public ushort Passes { get; set; }

        public ushort BigChancesCreated { get; set; }

        public ushort Crosses { get; set; }

        public ushort ThroughBalls { get; set; }

        public ushort AccurateLongBalls { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int FixtureId { get; set; }
        public Fixture Fixture { get; set; }
    }
}
