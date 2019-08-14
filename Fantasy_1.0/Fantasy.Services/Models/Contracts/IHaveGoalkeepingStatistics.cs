namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveGoalkeepingStatistics
    {
        short GoalkeepingSaves { get; set; }

        short GoalkeepingPenaltiesSaved { get; set; }

        short GoalkeepingPunches { get; set; }

        short GoalkeepingHighClaims { get; set; }

        short GoalkeepingCatches { get; set; }

        short GoalkeepingSweeperClearances { get; set; }

        short GoalkeepingGoalKicks { get; set; }
    }
}