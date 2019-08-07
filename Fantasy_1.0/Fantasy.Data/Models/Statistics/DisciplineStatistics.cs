using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.Players;

namespace Fantasy.Data.Models.Statistics
{
    public class DisciplineStatistics 
    {
        public ushort YellowCards { get; set; }

        public ushort RedCards { get; set; }

        public ushort Fouls { get; set; }

        public ushort Offsides { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int FixtureId { get; set; }
        public Fixture Fixture { get; set; }
    }
}
