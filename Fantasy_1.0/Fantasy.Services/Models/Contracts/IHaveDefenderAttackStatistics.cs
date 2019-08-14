namespace Fantasy.Services.Models.Contracts
{
    public interface IHaveDefenderAttackStatistics
    {
        short AttackGoals { get; set; }

        short AttackHitWoodwork { get; set; }
    }
}