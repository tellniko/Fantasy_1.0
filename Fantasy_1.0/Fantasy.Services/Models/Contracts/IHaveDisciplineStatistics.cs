namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveDisciplineStatistics
    {
        short DisciplineYellowCards { get; set; }

        short DisciplineRedCards { get; set; }

        short DisciplineFouls { get; set; }
    }
}