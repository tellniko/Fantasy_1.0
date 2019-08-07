using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.Players;

namespace Fantasy.Data.Models.Statistics
{
    public class DisciplineStatistics 
    {
        public short YellowCards { get; set; }

        public short RedCards { get; set; }

        public short Fouls { get; set; }

        public short Offsides { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int FixtureId { get; set; }
        public Fixture Fixture { get; set; }
    }
}
