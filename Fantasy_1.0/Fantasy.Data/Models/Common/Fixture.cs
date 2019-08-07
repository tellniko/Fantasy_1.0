using System;
using System.Collections.Generic;
using Fantasy.Data.Models.Statistics;

namespace Fantasy.Data.Models.Common
{
    public class Fixture : BaseModel<int>
    {
        public DateTime? DateTimeStart { get; set; }

        public bool Finished { get; set; }

        public int HomeTeamId { get; set; }
        public FootballClub HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public FootballClub AwayTeam { get; set; }

        public int GameWeekId { get; set; }
        public Gameweek Gameweek { get; set; }

        public IEnumerable<BaseStatistics> BaseStatistics { get; set; } = new List<BaseStatistics>();

        public IEnumerable<GoalkeepingStatistics> GoalkeepingStatistics { get; set; } = new List<GoalkeepingStatistics>();

        public IEnumerable<DefenceStatistics> DefenceStatistics { get; set; } = new List<DefenceStatistics>();

        public IEnumerable<TeamPlayStatistics> TeamPlayStatistics { get; set; } = new List<TeamPlayStatistics>();

        public IEnumerable<AttackStatistics> AttackStatistics { get; set; } = new List<AttackStatistics>();

        public IEnumerable<DisciplineStatistics> DisciplineStatistics { get; set; } = new List<DisciplineStatistics>();
    }
}
