﻿using Fantasy.Common.Attributes;
using Fantasy.Common.Mapping;
using Fantasy.Data.Models;
using Fantasy.Services.Models.Contracts;

namespace Fantasy.Services.Models
{
    public class MidfielderStatisticsServiceModel : IMapFrom<GameweekStatistics>
        ,IHaveMidfielderDefenceStatistics
        ,IHaveMidfielderTeamPlayStatistics
        ,IHaveMidfielderAttackStatistics
        ,IHaveDisciplineStatistics
        ,IHaveMatchStatistics
        ,IHaveOffcidesStatistics
    {
        [Points(Units = 20)] public short Appearances { get; set; }

        [Points(Units = 10)] public short Wins { get; set; }

        [Points(Units = -10)] public short Losses { get; set; }

        [Points(Units = -20)] public short YellowCards { get; set; }

        [Points(Units = -50)] public short RedCards { get; set; }

        [Points(Units = -5)] public short Fouls { get; set; }

        [Points(Units = -5)] public short Offsides { get; set; }

        [Points(Units = 3)] public short Tackles { get; set; }

        [Points(Units = 3)] public short BlockedShots { get; set; }

        [Points(Units = 3)] public short Interceptions { get; set; }

        [Points(Units = 3)] public short Clearances { get; set; }

        [Points(Units = 2)] public short HeadedClearance { get; set; }

        [Points(Units = 2)] public short Recoveries { get; set; }

        [Points(Units = 2)] public short DuelsWon { get; set; }

        [Points(Units = -5)] public short DuelsLost { get; set; }

        [Points(Units = 3)] public short SuccessfulFiftyFifties { get; set; }

        [Points(Units = 5)] public short AerialBattlesWon { get; set; }

        [Points(Units = -5)] public short AerialBattlesLost { get; set; }

        [Points(Units = -30)] public short ErrorsLeadingToGoal { get; set; }

        [Points(Units = 80)] public short Assists { get; set; }

        [Points(Units = 1)] public short Passes { get; set; }

        [Points(Units = 3)] public short AccurateLongBalls { get; set; }

        [Points(Units = 10)] public short BigChancesCreated { get; set; }

        [Points(Units = 5)] public short Crosses { get; set; }

        [Points(Units = 5)] public short ThroughBalls { get; set; }

        [Points(Units = 150)] public short Goals { get; set; }

        [Points(Units = 10)] public short HitWoodwork { get; set; }

        [Points(Units = 20)] public short PenaltiesScored { get; set; }

        [Points(Units = 30)] public short FreeKicksScored { get; set; }

        [Points(Units = 5)] public short Shots { get; set; }

        [Points(Units = 10)] public short ShotsOnTarget { get; set; }

        [Points(Units = -20)] public short BigChancesMissed { get; set; }
    }
}
