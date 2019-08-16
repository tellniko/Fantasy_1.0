﻿using Fantasy.Common.Mapping;
using Fantasy.Services.Models.Contracts;

namespace Fantasy.Services.Models
{
    public class MidfielderStatisticsServiceModel : IMapFrom<StatisticsServiceModel>
        ,IHaveStatistics
        ,IHaveMidfielderDefenceStatistics
        ,IHaveMidfielderTeamPlayStatistics
        ,IHaveMidfielderAttackStatistics
    {
        public short MatchAppearances { get; set; }
        public short MatchWins { get; set; }
        public short MatchLosses { get; set; }
        public short DisciplineYellowCards { get; set; }
        public short DisciplineRedCards { get; set; }
        public short DisciplineFouls { get; set; }
        public short DisciplineOffsides { get; set; }
        public short DefenceTackles { get; set; }
        public short DefenceBlockedShots { get; set; }
        public short DefenceInterceptions { get; set; }
        public short DefenceClearances { get; set; }
        public short DefenceHeadedClearance { get; set; }
        public short DefenceRecoveries { get; set; }
        public short DefenceDuelsWon { get; set; }
        public short DefenceDuelsLost { get; set; }
        public short DefenceSuccessfulFiftyFifties { get; set; }
        public short DefenceAerialBattlesWon { get; set; }
        public short DefenceAerialBattlesLost { get; set; }
        public short DefenceErrorsLeadingToGoal { get; set; }
        public short TeamPlayAssists { get; set; }
        public short TeamPlayPasses { get; set; }
        public short TeamPlayAccurateLongBalls { get; set; }
        public short TeamPlayBigChancesCreated { get; set; }
        public short TeamPlayCrosses { get; set; }
        public short TeamPlayThroughBalls { get; set; }
        public short AttackGoals { get; set; }
        public short AttackHitWoodwork { get; set; }
        public short AttackPenaltiesScored { get; set; }
        public short AttackFreeKicksScored { get; set; }
        public short AttackShots { get; set; }
        public short AttackShotsOnTarget { get; set; }
        public short AttackBigChancesMissed { get; set; }
    }
}