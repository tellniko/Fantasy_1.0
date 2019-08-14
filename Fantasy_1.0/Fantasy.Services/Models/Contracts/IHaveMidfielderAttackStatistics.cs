namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveMidfielderAttackStatistics : IHaveDefenderAttackStatistics
    {
        short AttackPenaltiesScored { get; set; }

        short AttackFreeKicksScored { get; set; }

        short AttackShots { get; set; }

        short AttackShotsOnTarget { get; set; }

        short AttackBigChancesMissed { get; set; }
    }
}