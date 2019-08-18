using System;
using System.Collections.Generic;
using Fantasy.Data.Models.Statistics;

namespace Fantasy.Data.Models.Common
{
    public class Gameweek : BaseModel<int>
    {
        //todo bit
        public byte Number { get; set; }

        public bool Finished { get; set; } = false;

        public DateTime Start { get; set; }

        public int SeasonId { get; set; }
        public Season Season { get; set; }

        public IEnumerable<Fixture> Fixtures { get; set; } = new List<Fixture>();

        public IEnumerable<MatchStatistics> MatchStatistics { get; set; } = new List<MatchStatistics>();

        public IEnumerable<GoalkeepingStatistics> GoalkeepingStatistics { get; set; } = new List<GoalkeepingStatistics>();

        public IEnumerable<DefenceStatistics> DefenceStatistics { get; set; } = new List<DefenceStatistics>();

        public IEnumerable<TeamPlayStatistics> TeamPlayStatistics { get; set; } = new List<TeamPlayStatistics>();

        public IEnumerable<AttackStatistics> AttackStatistics { get; set; } = new List<AttackStatistics>();

        public IEnumerable<DisciplineStatistics> DisciplineStatistics { get; set; } = new List<DisciplineStatistics>();
    }
}
