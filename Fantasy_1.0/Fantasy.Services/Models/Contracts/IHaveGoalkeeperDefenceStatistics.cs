namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveGoalkeeperDefenceStatistics
    {
        short DefenceCleanSheets { get; set; }

        short DefenceGoalsConceded { get; set; }

        short DefenceErrorsLeadingToGoal { get; set; }

        short DefenceOwnGoals { get; set; }
    }
}