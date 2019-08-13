namespace Fantasy.Data.Models.Statistics.Contracts
{
    public interface ITeamPlayStatistics
    {
        short Assists { get; set; }

        short Passes { get; set; }

        short BigChancesCreated { get; set; }

        short Crosses { get; set; }

        short ThroughBalls { get; set; }

        short AccurateLongBalls { get; set; }
    }
}