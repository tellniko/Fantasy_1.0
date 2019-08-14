namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveMatchStatistics
    {
        short MatchAppearances { get; set; }

        short MatchWins { get; set; }

        short MatchLosses { get; set; }
    }
}