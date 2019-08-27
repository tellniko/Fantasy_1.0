using System.ComponentModel.DataAnnotations;

namespace Fantasy.Data.Models.Statistics
{
    public class TeamPlayStatistics : BaseStatistics
    {
        [Range(0, short.MaxValue)]
        public short Assists { get; set; }

        [Range(0, short.MaxValue)]
        public short Passes { get; set; }

        [Range(0, short.MaxValue)]
        public short BigChancesCreated { get; set; }

        [Range(0, short.MaxValue)]
        public short Crosses { get; set; }

        [Range(0, short.MaxValue)]
        public short ThroughBalls { get; set; }

        [Range(0, short.MaxValue)]
        public short AccurateLongBalls { get; set; }
    }
}
