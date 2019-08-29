namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveForwardTeamPlayStatistics 
    {
        short BigChancesCreated { get; set; }

        short Crosses { get; set; }

        short Assists { get; set; }

        short Passes { get; set; }
    }
}