using Fantasy.Common.Attributes;
using Fantasy.Common.Mapping;
using Fantasy.Data.Models;
using Fantasy.Services.Models.Contracts;

namespace Fantasy.Services.Models
{
    public class GoalkeeperStatisticsServiceModel : IMapFrom<GameweekStatistics> 
        ,IHaveGoalkeepingStatistics
        ,IHaveGoalkeeperDefenceStatistics
        ,IHaveGoalkeeperTeamPlayStatistics
        ,IHaveDisciplineStatistics
        ,IHaveMatchStatistics
    {
        [Points(Units = 20)] public short Appearances { get; set; }

        [Points(Units = 10)] public short Wins { get; set; }

        [Points(Units = -10)] public short Losses { get; set; }

        [Points(Units = -20)] public short YellowCards { get; set; }

        [Points(Units = -50)] public short RedCards { get; set; }

        [Points(Units = -5)] public short Fouls { get; set; }

        [Points(Units = 15)] public short Saves { get; set; }

        [Points(Units = 100)] public short PenaltiesSaved { get; set; }

        [Points(Units = 5)] public short Punches { get; set; }

        [Points(Units = 10)] public short HighClaims { get; set; }

        [Points(Units = 5)] public short Catches { get; set; }

        [Points(Units = 20)] public short SweeperClearances { get; set; }

        [Points(Units = 1)] public short GoalKicks { get; set; }

        [Points(Units = 100)] public short CleanSheets { get; set; }

        [Points(Units = -30)] public short GoalsConceded { get; set; }

        [Points(Units = -30)] public short ErrorsLeadingToGoal { get; set; }

        [Points(Units = -50)] public short OwnGoals { get; set; }

        [Points(Units = 300)] public short Goals { get; set; }

        [Points(Units = 100)] public short Assists { get; set; }

        [Points(Units = 1)] public short Passes { get; set; }

        [Points(Units = 5)] public short AccurateLongBalls { get; set; }
    }
}


