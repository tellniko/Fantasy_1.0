namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveMidfielderAttackStatistics 
    {
        short PenaltiesScored { get; set; }

        short FreeKicksScored { get; set; }

        short Shots { get; set; }

        short ShotsOnTarget { get; set; }

        short BigChancesMissed { get; set; }

        short Goals { get; set; }

        short HitWoodwork { get; set; }
    }
}