using Fantasy.Data.Models.Statistics;

namespace Fantasy.Services.Models
{
    public class StatisticsServiceModel
    {
        public GoalkeepingStatistics Goalkeeping { get; set; }

        public DefenceStatistics Defence { get; set; }

        public TeamPlayStatistics TeamPlay { get; set; }

        public AttackStatistics Attack { get; set; }

        public DisciplineStatistics Discipline { get; set; }

        public MatchStatistics Match { get; set; }

    }
}