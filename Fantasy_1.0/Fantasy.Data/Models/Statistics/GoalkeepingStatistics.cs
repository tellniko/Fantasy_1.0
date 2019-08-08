namespace Fantasy.Data.Models.Statistics
{
    public class GoalkeepingStatistics : BaseStatistics
    {
        public short Saves { get; set; }

        public short PenaltiesSaved { get; set; }

        public short Punches { get; set; }

        public short HighClaims { get; set; }

        public short Catches { get; set; }

        public short SweeperClearances { get; set; }

        public short GoalKicks { get; set; }
    }
}
