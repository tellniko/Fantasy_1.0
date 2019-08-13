namespace Fantasy.Data.Models.Statistics.Contracts
{
    public interface IAttackStatistics
    {
        short Goals { get; set; }

        short PenaltiesScored { get; set; }

        short FreeKicksScored { get; set; }

        short Shots { get; set; }

        short ShotsOnTarget { get; set; }

        short HitWoodwork { get; set; }

        short BigChancesMissed { get; set; }
    }
}
