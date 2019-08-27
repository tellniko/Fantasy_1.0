using Fantasy.Common.Attributes;
using Fantasy.Common.Mapping;
using Fantasy.Services.Models.Contracts;

namespace Fantasy.Services.Models
{
    public class DefenderStatisticsServiceModel : IMapFrom<StatisticsServiceModel> 
        ,IHaveStatistics
        ,IHaveDefenderDefenceStatistics
        ,IHaveDefenderTeamPlayStatistics
        ,IHaveDefenderAttackStatistics
        ,IHaveOffcidesStatistics
    //, IHaveLastManTacklesStatistics
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

        [Points(Units = 100)]
        public short DefenceCleanSheets { get; set; }

        [Points(Units = -30)]
        public short DefenceGoalsConceded { get; set; }

        [Points(Units = -30)]
        public short DefenceErrorsLeadingToGoal { get; set; }

        [Points(Units = -50)]
        public short DefenceOwnGoals { get; set; }

        [Points(Units = 5)]
        public short DefenceTackles { get; set; }

        [Points(Units = 10)]
        public short DefenceBlockedShots { get; set; }

        [Points(Units = 5)]
        public short DefenceInterceptions { get; set; }

        [Points(Units = 3)]
        public short DefenceClearances { get; set; }

        [Points(Units = 2)]
        public short DefenceHeadedClearance { get; set; }

        [Points(Units = 3)]
        public short DefenceRecoveries { get; set; }

        [Points(Units = 3)]
        public short DefenceDuelsWon { get; set; }

        [Points(Units = -3)]
        public short DefenceDuelsLost { get; set; }

        [Points(Units = 10)]
        public short DefenceSuccessfulFiftyFifties { get; set; }

        [Points(Units = 3)]
        public short DefenceAerialBattlesWon { get; set; }

        [Points(Units = -3)]
        public short DefenceAerialBattlesLost { get; set; }

        [Points(Units = 50)]
        public short TeamPlayAssists { get; set; }

        [Points(Units = 1)]
        public short TeamPlayPasses { get; set; }

        [Points(Units = 3)]
        public short TeamPlayAccurateLongBalls { get; set; }

        [Points(Units = 20)]
        public short TeamPlayBigChancesCreated { get; set; }

        [Points(Units = 5)]
        public short TeamPlayCrosses { get; set; }

        [Points(Units = 10)]
        public short TeamPlayThroughBalls { get; set; }

        [Points(Units = 100)]
        public short AttackGoals { get; set; }

        [Points(Units = 10)]
        public short AttackHitWoodwork { get; set; }

        public string Goalkeeping { get; }
        public string Defence { get; }
        public string Attack { get; }
        public string TeamPlay { get; }
        public string Discipline { get; }
        public string Match { get; }
    }

   
}
