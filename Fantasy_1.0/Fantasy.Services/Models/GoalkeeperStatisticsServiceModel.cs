using Fantasy.Common.Mapping;
using Fantasy.Services.Models.Contracts;

namespace Fantasy.Services.Models
{
    public class GoalkeeperStatisticsServiceModel : IMapFrom<StatisticsServiceModel>
        ,IHaveStatistics
        ,IHaveGoalkeepingStatistics
        ,IHaveGoalkeeperDefenceStatistics
        ,IHaveGoalkeeperTeamPlayStatistics
    {
        //public short AttackGoals { get; set; }

        public short MatchAppearances { get; set; }
        public short MatchWins { get; set; }
        public short MatchLosses { get; set; }
        public short DisciplineYellowCards { get; set; }
        public short DisciplineRedCards { get; set; }
        public short DisciplineFouls { get; set; }
        public short DisciplineOffsides { get; set; }
        public short GoalkeepingSaves { get; set; }
        public short GoalkeepingPenaltiesSaved { get; set; }
        public short GoalkeepingPunches { get; set; }
        public short GoalkeepingHighClaims { get; set; }
        public short GoalkeepingCatches { get; set; }
        public short GoalkeepingSweeperClearances { get; set; }
        public short GoalkeepingGoalKicks { get; set; }
        public short DefenceCleanSheets { get; set; }
        public short DefenceGoalsConceded { get; set; }
        public short DefenceErrorsLeadingToGoal { get; set; }
        public short DefenceOwnGoals { get; set; }
        public short TeamPlayAssists { get; set; }
        public short TeamPlayPasses { get; set; }
        public short TeamPlayAccurateLongBalls { get; set; }
    }
}


