using Fantasy.Common.Attributes;
using Fantasy.Common.Mapping;
using Fantasy.Services.Models.Contracts;

namespace Fantasy.Services.Models
{
    public class ForwardStatisticsServiceModel : IMapFrom<StatisticsServiceModel>
        ,IHaveStatistics
        ,IHaveForwardDefenceStatistics
        ,IHaveForwardTeamPlayStatistics
        ,IHaveForwardAttackStatistics
    {
        [Points(Units = 20)]
        public short MatchAppearances { get; set; }

        [Points(Units = 10)]
        public short MatchWins { get; set; }

        [Points(Units = -10)]
        public short MatchLosses { get; set; }

        [Points(Units = -20)]
        public short DisciplineYellowCards { get; set; }

        [Points(Units = -50)]
        public short DisciplineRedCards { get; set; }

        [Points(Units = -5)]
        public short DisciplineFouls { get; set; }

        [Points(Units = -5)]
        public short DisciplineOffsides { get; set; }

        [Points(Units = 10)]
        public short DefenceTackles { get; set; }

        [Points(Units = 10)]
        public short DefenceBlockedShots { get; set; }

        [Points(Units = 5)]
        public short DefenceInterceptions { get; set; }

        [Points(Units = 5)]
        public short DefenceClearances { get; set; }

        [Points(Units = 5)]
        public short DefenceHeadedClearance { get; set; }

        [Points(Units = 40)]
        public short TeamPlayAssists { get; set; }

        [Points(Units = 1)]
        public short TeamPlayPasses { get; set; }

        [Points(Units = 15)]
        public short TeamPlayBigChancesCreated { get; set; }

        [Points(Units = 5)]
        public short TeamPlayCrosses { get; set; }

        [Points(Units = 70)]
        public short AttackGoals { get; set; }

        [Points(Units = 10)]
        public short AttackHitWoodwork { get; set; }

        [Points(Units = 10)]
        public short AttackPenaltiesScored { get; set; }

        [Points(Units = 20)]
        public short AttackFreeKicksScored { get; set; }

        [Points(Units = 3)]
        public short AttackShots { get; set; }

        [Points(Units = 3)]
        public short AttackShotsOnTarget { get; set; }

        [Points(Units = -20)]
        public short AttackBigChancesMissed { get; set; }

        public string Goalkeeping { get; }
        public string Defence { get; }
        public string Attack { get; }
        public string TeamPlay { get; }
        public string Discipline { get; }
        public string Match { get; }
    }
}
