using Fantasy.Data.Models.Game;
using Fantasy.Data.Models.Statistics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fantasy.Data.Models.FootballPlayers;

namespace Fantasy.Data.Models.Common
{
    using static DataConstants;

    public class Gameweek : BaseModel<int>
    {
        [MinLength(CommonNameMinLength)]
        [MaxLength(CommonNameMaxLength)]
        public string Name { get; set; }

        public bool Finished { get; set; } = false;

        public DateTime? Start { get; set; }

        public List<Fixture> Fixtures { get; set; } = new List<Fixture>();

        public List<MatchStatistics> MatchStatistics { get; set; } = new List<MatchStatistics>();

        public List<GoalkeepingStatistics> GoalkeepingStatistics { get; set; } = new List<GoalkeepingStatistics>();

        public List<DefenceStatistics> DefenceStatistics { get; set; } = new List<DefenceStatistics>();

        public List<TeamPlayStatistics> TeamPlayStatistics { get; set; } = new List<TeamPlayStatistics>();

        public List<AttackStatistics> AttackStatistics { get; set; } = new List<AttackStatistics>();

        public List<DisciplineStatistics> DisciplineStatistics { get; set; } = new List<DisciplineStatistics>();

        public List<GameweekStatus> GameweekStatuses { get; set; } = new List<GameweekStatus>();

        public List<GameweekPoints> GameweekPoints { get; set; } = new List<GameweekPoints>();

        public List<GameweekScore> GameweekScoreses { get; set; } = new List<GameweekScore>();
    }
}
