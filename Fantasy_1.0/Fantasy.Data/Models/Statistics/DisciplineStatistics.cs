using Fantasy.Common.Attributes;
using Fantasy.Data.Models.Statistics.Contracts;

namespace Fantasy.Data.Models.Statistics
{
    public class DisciplineStatistics : BaseStatistics, IDisciplineStatistics
    {
        public short YellowCards { get; set; }

        public short RedCards { get; set; }

        public short Fouls { get; set; }

        public short Offsides { get; set; }
    }
}
