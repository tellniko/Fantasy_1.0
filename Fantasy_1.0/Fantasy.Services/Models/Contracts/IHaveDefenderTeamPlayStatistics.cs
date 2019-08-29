namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveDefenderTeamPlayStatistics 
    {
        short BigChancesCreated { get; set; }

        short Crosses { get; set; }

        short ThroughBalls { get; set; }

        short AccurateLongBalls { get; set; }

        short Assists { get; set; }

        short Passes { get; set; }

        short Goals { get; set; }
    }
}