namespace Fantasy.Data.Models.Statistics.Contracts
{
    public interface IMatchStatistics
    {
        short Appearances { get; set; }

        short Wins { get; set; }

        short Losses { get; set; }
    }
}