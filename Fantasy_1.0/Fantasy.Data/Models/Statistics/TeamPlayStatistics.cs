namespace Fantasy.Data.Models.Statistics
{
    public class TeamPlayStatistics : BaseStatistics
    {
        public short Assists { get; set; }

        public short Passes { get; set; }

        public short BigChancesCreated { get; set; }

        public short Crosses { get; set; }

        public short ThroughBalls { get; set; }

        public short AccurateLongBalls { get; set; }
    }
}
