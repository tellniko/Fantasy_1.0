using AutoMapper;
using Fantasy.Common.Attributes;
using Fantasy.Common.Mapping;
using Fantasy.Services.Models.Contracts;

namespace Fantasy.Services.Models
{
    public class GoalkeeperStatisticsServiceModel : IMapFrom<StatisticsServiceModel>, IHaveCustomMappings
        ,IHaveStatistics
        ,IHaveGoalkeepingStatistics
        ,IHaveGoalkeeperDefenceStatistics
        ,IHaveGoalkeeperTeamPlayStatistics
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

        [Points(Units = 15)]
        public short GoalkeepingSaves { get; set; }

        [Points(Units = 100)]
        public short GoalkeepingPenaltiesSaved { get; set; }

        [Points(Units = 5)]
        public short GoalkeepingPunches { get; set; }

        [Points(Units = 10)]
        public short GoalkeepingHighClaims { get; set; }

        [Points(Units = 5)]
        public short GoalkeepingCatches { get; set; }

        [Points(Units = 20)]
        public short GoalkeepingSweeperClearances { get; set; }

        [Points(Units = 1)]
        public short GoalkeepingGoalKicks { get; set; }

        [Points(Units = 100)]
        public short DefenceCleanSheets { get; set; }

        [Points(Units = -30)]
        public short DefenceGoalsConceded { get; set; }

        [Points(Units = -30)]
        public short DefenceErrorsLeadingToGoal { get; set; }

        [Points(Units = -50)]
        public short DefenceOwnGoals { get; set; }

        [Points(Units = 150)]
        public short TeamPlayGoals { get; set; }

        [Points(Units = 50)]
        public short TeamPlayAssists { get; set; }

        [Points(Units = 1)]
        public short TeamPlayPasses { get; set; }

        [Points(Units = 5)]
        public short TeamPlayAccurateLongBalls { get; set; }


        public string Goalkeeping { get; }
        public string Defence { get; }
        public string Attack { get; }
        public string TeamPlay { get; }
        public string Discipline { get; }
        public string Match { get; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<StatisticsServiceModel, GoalkeeperStatisticsServiceModel>()
                .ForMember(gs => gs.TeamPlayGoals, cfg => cfg.MapFrom(sm => sm.Attack.Goals));
        }
    }
}


