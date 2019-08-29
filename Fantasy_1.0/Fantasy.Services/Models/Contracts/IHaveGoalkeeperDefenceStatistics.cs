namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveGoalkeeperDefenceStatistics
    {
        short CleanSheets { get; set; }

        short GoalsConceded { get; set; }

        short ErrorsLeadingToGoal { get; set; }

        short OwnGoals { get; set; }
    }
}