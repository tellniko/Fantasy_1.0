using System.ComponentModel.DataAnnotations;

namespace Fantasy.Data.Models.Statistics
{
    public class DisciplineStatistics : BaseStatistics
    {
        [Range(0, short.MaxValue)]
        public short YellowCards { get; set; }

        [Range(0, short.MaxValue)]
        public short RedCards { get; set; }

        [Range(0, short.MaxValue)]
        public short Fouls { get; set; }

        [Range(0, short.MaxValue)]
        public short Offsides { get; set; }
    }
}
