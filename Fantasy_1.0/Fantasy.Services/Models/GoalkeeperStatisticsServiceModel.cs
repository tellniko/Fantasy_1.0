using AutoMapper;
using Fantasy.Common.Mapping;
using Fantasy.Data.Models.FootballPlayers;
using System.Linq;
using Fantasy.Services.Implementations;

namespace Fantasy.Services.Models
{
    public class GoalkeeperStatisticsServiceModel : IMapFrom<StatisticsServiceModel>
    {
        #region Goalkeeping
        public short GoalkeepingSaves { get; set; }

        public short GoalkeepingPenaltiesSaved { get; set; }

        public short GoalkeepingPunches { get; set; }

        public short GoalkeepingHighClaims { get; set; }

        public short GoalkeepingCatches { get; set; }

        public short GoalkeepingSweeperClearances { get; set; }

        public short GoalkeepingGoalKicks { get; set; }
        #endregion

        #region Defence
        public short DefenceCleanSheets { get; set; }

        public short DefenceGoalsConceded { get; set; }

        public short DefenceErrorsLeadingToGoal { get; set; }
        #endregion

        #region TeamPlay
        public short TeamPlayAssists { get; set; }

        public short TeamPlayPasses { get; set; }

        public short TeamPlayAccurateLongBalls { get; set; }

        public short TeamPlayGoals { get; set; }
        #endregion

        #region Discipline
        public short DisciplineYellowCards { get; set; }

        public short DisciplineRedCards { get; set; }

        public short DisciplineFouls { get; set; }
        #endregion

        #region Match
        public short MatchAppearances { get; set; }

        public short MatchWins { get; set; }

        public short MatchLosses { get; set; }
        #endregion
    }
}
