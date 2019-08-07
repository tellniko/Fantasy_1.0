using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.Players;

namespace Fantasy.Data.Models.Statistics
{
    public class TeamPlayStatistics 
    {
        public short Assists { get; set; }

        public short Passes { get; set; }

        public short BigChancesCreated { get; set; }

        public short Crosses { get; set; }

        public short ThroughBalls { get; set; }

        public short AccurateLongBalls { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int FixtureId { get; set; }
        public Fixture Fixture { get; set; }
    }
}
