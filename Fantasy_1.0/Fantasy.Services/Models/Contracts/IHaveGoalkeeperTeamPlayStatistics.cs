namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveGoalkeeperTeamPlayStatistics
    { 
        short AccurateLongBalls { get; set; }

        short Assists { get; set; }

        short Passes { get; set; }

        short Goals { get; set; }
    }
}