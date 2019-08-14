namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveCommonTeamPlayStatistics
    {
        short TeamPlayAssists { get; set; }

        short TeamPlayPasses { get; set; }
    }
}