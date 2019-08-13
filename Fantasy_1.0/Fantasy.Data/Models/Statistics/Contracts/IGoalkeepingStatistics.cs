namespace Fantasy.Data.Models.Statistics.Contracts
{
    public interface IGoalkeepingStatistics
    {
        short Saves { get; set; }

        short PenaltiesSaved { get; set; }

        short Punches { get; set; }

        short HighClaims { get; set; }

        short Catches { get; set; }

        short SweeperClearances { get; set; }

        short GoalKicks { get; set; }
    }
}
