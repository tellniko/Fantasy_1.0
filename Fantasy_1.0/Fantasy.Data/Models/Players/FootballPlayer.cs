using System.Collections.Generic;
using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.Statistics;

namespace Fantasy.Data.Models.Players
{
    public class FootballPlayer : BaseModel<int>
    {
        public bool IsFirstTeam { get; set; } = true;

        public bool IsInjured { get; set; } = false;

        public bool IsPlayable { get; set; } = true;

        public decimal Price { get; set; }

        public FootballPlayerInfo FootballPlayerInfo { get; set; }

        public int PositionId { get; set; }
        public FootballPlayerPosition Position { get; set; }

        public int FootballClubId { get; set; }
        public FootballClub FootballClub { get; set; }

        public IEnumerable<MatchStatistics> BaseStatistics { get; set; } = new List<MatchStatistics>();

        public IEnumerable<GoalkeepingStatistics> GoalkeepingStatistics { get; set; } = new List<GoalkeepingStatistics>();

        public IEnumerable<DefenceStatistics> DefenceStatistics { get; set; } = new List<DefenceStatistics>();

        public IEnumerable<TeamPlayStatistics> TeamPlayStatistics { get; set; } = new List<TeamPlayStatistics>();

        public IEnumerable<AttackStatistics> AttackStatistics { get; set; } = new List<AttackStatistics>();

        public IEnumerable<DisciplineStatistics> DisciplineStatistics { get; set; } = new List<DisciplineStatistics>();
    }
}
