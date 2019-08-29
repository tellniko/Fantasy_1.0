namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveMatchStatistics
    {
        short Appearances { get; set; }

        short Wins { get; set; }

        short Losses { get; set; }
    }
}