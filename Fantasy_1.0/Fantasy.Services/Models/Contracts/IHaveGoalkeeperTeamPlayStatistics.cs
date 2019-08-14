namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveGoalkeeperTeamPlayStatistics : IHaveCommonTeamPlayStatistics
    {
        short TeamPlayAccurateLongBalls { get; set; }
    }
}