namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveForwardTeamPlayStatistics : IHaveCommonTeamPlayStatistics
    {
        short TeamPlayBigChancesCreated { get; set; }

        short TeamPlayCrosses { get; set; }
    }
}