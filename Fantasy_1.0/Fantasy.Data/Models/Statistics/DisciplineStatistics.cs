using Fantasy.Common.Attributes;

namespace Fantasy.Data.Models.Statistics
{
    public class DisciplineStatistics : BaseStatistics
    {
        [Goalkeeper]
        public short YellowCards { get; set; }

        public short RedCards { get; set; }

        public short Fouls { get; set; }

        public short Offsides { get; set; }
    }
}
