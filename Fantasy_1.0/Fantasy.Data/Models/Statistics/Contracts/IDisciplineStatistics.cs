namespace Fantasy.Data.Models.Statistics.Contracts
{
    public interface IDisciplineStatistics
    {
       short YellowCards { get; set; }

       short RedCards { get; set; }

       short Fouls { get; set; }

       short Offsides { get; set; }
    }
}
