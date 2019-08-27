﻿using Fantasy.Common.Attributes;
using Fantasy.Common.Mapping;
using Fantasy.Services.Models.Contracts;

namespace Fantasy.Services.Models
{
    public class MidfielderStatisticsServiceModel : IMapFrom<StatisticsServiceModel>
        ,IHaveStatistics
        ,IHaveMidfielderDefenceStatistics
        ,IHaveMidfielderTeamPlayStatistics
        ,IHaveMidfielderAttackStatistics
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

        [Points(Units = 5)]
        public short DefenceTackles { get; set; }

        [Points(Units = 10)]
        public short DefenceBlockedShots { get; set; }

        [Points(Units = 5)]
        public short DefenceInterceptions { get; set; }

        [Points(Units = 5)]
        public short DefenceClearances { get; set; }

        [Points(Units = 2)]
        public short DefenceHeadedClearance { get; set; }

        [Points(Units = 2)]
        public short DefenceRecoveries { get; set; }

        [Points(Units = 2)]
        public short DefenceDuelsWon { get; set; }

        [Points(Units = -5)]
        public short DefenceDuelsLost { get; set; }

        [Points(Units = 5)]
        public short DefenceSuccessfulFiftyFifties { get; set; }

        [Points(Units = 5)]
        public short DefenceAerialBattlesWon { get; set; }

        [Points(Units = -5)]
        public short DefenceAerialBattlesLost { get; set; }

        [Points(Units = -30)]
        public short DefenceErrorsLeadingToGoal { get; set; }

        [Points(Units = 40)]
        public short TeamPlayAssists { get; set; }

        [Points(Units = 1)]
        public short TeamPlayPasses { get; set; }

        [Points(Units = 3)]
        public short TeamPlayAccurateLongBalls { get; set; }

        [Points(Units = 15)]
        public short TeamPlayBigChancesCreated { get; set; }

        [Points(Units = 5)]
        public short TeamPlayCrosses { get; set; }

        [Points(Units = 8)]
        public short TeamPlayThroughBalls { get; set; }

        [Points(Units = 80)]
        public short AttackGoals { get; set; }

        [Points(Units = 10)]
        public short AttackHitWoodwork { get; set; }

        [Points(Units = 20)]
        public short AttackPenaltiesScored { get; set; }

        [Points(Units = 30)]
        public short AttackFreeKicksScored { get; set; }

        [Points(Units = 10)]
        public short AttackShots { get; set; }

        [Points(Units = 10)]
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
