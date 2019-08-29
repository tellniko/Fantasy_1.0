namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveDisciplineStatistics
    {
        short YellowCards { get; set; }

        short RedCards { get; set; }

        short Fouls { get; set; }
    }
}