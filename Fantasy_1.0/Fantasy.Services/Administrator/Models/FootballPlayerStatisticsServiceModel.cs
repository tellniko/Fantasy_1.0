using Fantasy.Common.Mapping;
using Fantasy.Services.Models;
using Fantasy.Services.Models.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Fantasy.Services.Administrator.Models
{
    public class FootballPlayerStatisticsServiceModel : IMapFrom<StatisticsServiceModel>, IMapTo<StatisticsServiceModel>,
            IHaveDefenderAttackStatistics,
            IHaveDefenderDefenceStatistics,
            IHaveDefenderTeamPlayStatistics,
            IHaveGoalkeeperDefenceStatistics,
            IHaveGoalkeeperTeamPlayStatistics,
            IHaveGoalkeepingStatistics,
            IHaveMidfielderAttackStatistics,
            IHaveMidfielderDefenceStatistics,
            IHaveMidfielderTeamPlayStatistics,
            IHaveForwardAttackStatistics,
            IHaveForwardDefenceStatistics,
            IHaveForwardTeamPlayStatistics,
            IHaveDisciplineStatistics,
            IHaveMatchStatistics,
            IHaveOffcidesStatistics
    {
        [Range(0, short.MaxValue)] public short AttackGoals { get; set; }
        [Range(0, short.MaxValue)] public short AttackPenaltiesScored { get; set; }
        [Range(0, short.MaxValue)] public short AttackFreeKicksScored { get; set; }
        [Range(0, short.MaxValue)] public short AttackShots { get; set; }
        [Range(0, short.MaxValue)] public short AttackShotsOnTarget { get; set; }
        [Range(0, short.MaxValue)] public short AttackHitWoodwork { get; set; }
        [Range(0, short.MaxValue)] public short AttackBigChancesMissed { get; set; }


        [Range(0, short.MaxValue)] public short DefenceTackles { get; set; }
        [Range(0, short.MaxValue)] public short DefenceBlockedShots { get; set; }
        [Range(0, short.MaxValue)] public short DefenceInterceptions { get; set; }
        [Range(0, short.MaxValue)] public short DefenceClearances { get; set; }
        [Range(0, short.MaxValue)] public short DefenceHeadedClearance { get; set; }
        [Range(0, short.MaxValue)] public short DefenceRecoveries { get; set; }
        [Range(0, short.MaxValue)] public short DefenceDuelsWon { get; set; }
        [Range(0, short.MaxValue)] public short DefenceDuelsLost { get; set; }
        [Range(0, short.MaxValue)] public short DefenceSuccessfulFiftyFifties { get; set; }
        [Range(0, short.MaxValue)] public short DefenceAerialBattlesWon { get; set; }
        [Range(0, short.MaxValue)] public short DefenceAerialBattlesLost { get; set; }
        [Range(0, short.MaxValue)] public short DefenceCleanSheets { get; set; }
        [Range(0, short.MaxValue)] public short DefenceGoalsConceded { get; set; }
        [Range(0, short.MaxValue)] public short DefenceLastManTackles { get; set; }
        [Range(0, short.MaxValue)] public short DefenceOwnGoals { get; set; }
        [Range(0, short.MaxValue)] public short DefenceErrorsLeadingToGoal { get; set; }


        [Range(0, short.MaxValue)] public short DisciplineYellowCards { get; set; }
        [Range(0, short.MaxValue)] public short DisciplineRedCards { get; set; }
        [Range(0, short.MaxValue)] public short DisciplineFouls { get; set; }
        [Range(0, short.MaxValue)] public short DisciplineOffsides { get; set; }


        [Range(0, short.MaxValue)] public short GoalkeepingSaves { get; set; }
        [Range(0, short.MaxValue)] public short GoalkeepingPenaltiesSaved { get; set; }
        [Range(0, short.MaxValue)] public short GoalkeepingPunches { get; set; }
        [Range(0, short.MaxValue)] public short GoalkeepingHighClaims { get; set; }
        [Range(0, short.MaxValue)] public short GoalkeepingCatches { get; set; }
        [Range(0, short.MaxValue)] public short GoalkeepingSweeperClearances { get; set; }
        [Range(0, short.MaxValue)] public short GoalkeepingGoalKicks { get; set; }


        [Range(0, short.MaxValue)] public short TeamPlayAssists { get; set; }
        [Range(0, short.MaxValue)] public short TeamPlayPasses { get; set; }
        [Range(0, short.MaxValue)] public short TeamPlayBigChancesCreated { get; set; }
        [Range(0, short.MaxValue)] public short TeamPlayCrosses { get; set; }
        [Range(0, short.MaxValue)] public short TeamPlayThroughBalls { get; set; }
        [Range(0, short.MaxValue)] public short TeamPlayAccurateLongBalls { get; set; }


        [Range(0, short.MaxValue)] public short MatchAppearances { get; set; }
        [Range(0, short.MaxValue)] public short MatchWins { get; set; }
        [Range(0, short.MaxValue)] public short MatchLosses { get; set; }

        public int MatchPlayerId { get; set; }
        public int MatchGameweekId { get; set; }

    }
}
