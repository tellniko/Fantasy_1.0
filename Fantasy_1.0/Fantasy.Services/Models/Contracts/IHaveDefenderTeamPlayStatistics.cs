namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveDefenderTeamPlayStatistics : IHaveGoalkeeperTeamPlayStatistics
    {
        short TeamPlayBigChancesCreated { get; set; }

        short TeamPlayCrosses { get; set; }

        short TeamPlayThroughBalls { get; set; }
    }
}