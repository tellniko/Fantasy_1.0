namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveMidfielderTeamPlayStatistics 
    {
        short AccurateLongBalls { get; set; }

        short BigChancesCreated { get; set; }

        short Crosses { get; set; }

        short ThroughBalls { get; set; }

        short Assists { get; set; }

        short Passes { get; set; }
    }
}