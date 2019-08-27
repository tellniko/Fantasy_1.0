using System.ComponentModel.DataAnnotations;

namespace Fantasy.Data.Models.Statistics
{
    public class GoalkeepingStatistics : BaseStatistics
    {

        [Range(0, short.MaxValue)]
        public short Saves { get; set; }

        [Range(0, short.MaxValue)]
        public short PenaltiesSaved { get; set; }

        [Range(0, short.MaxValue)]
        public short Punches { get; set; }

        [Range(0, short.MaxValue)]
        public short HighClaims { get; set; }

        [Range(0, short.MaxValue)]
        public short Catches { get; set; }

        [Range(0, short.MaxValue)]
        public short SweeperClearances { get; set; }

        [Range(0, short.MaxValue)]
        public short GoalKicks { get; set; }
    }
}
