using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.Statistics;
using System.Collections.Generic;
using Fantasy.Data.Models.Game;

namespace Fantasy.Data.Models.FootballPlayers
{
    public class FootballPlayer : BaseModel<int>
    {
        public bool IsInjured { get; set; } = false;

        public bool IsPlayable { get; set; } = true;

        public decimal Price { get; set; }

        public FootballPlayerInfo Info { get; set; }

        public int FootballPlayerPositionId { get; set; }
        public FootballPlayerPosition FootballPlayerPosition { get; set; }

        public int FootballClubId { get; set; }
        public FootballClub FootballClub { get; set; }

        public IEnumerable<MatchStatistics> BaseStatistics { get; set; } = new List<MatchStatistics>();

        public IEnumerable<GoalkeepingStatistics> GoalkeepingStatistics { get; set; } = new List<GoalkeepingStatistics>();

        public IEnumerable<DefenceStatistics> DefenceStatistics { get; set; } = new List<DefenceStatistics>();

        public IEnumerable<TeamPlayStatistics> TeamPlayStatistics { get; set; } = new List<TeamPlayStatistics>();

        public IEnumerable<AttackStatistics> AttackStatistics { get; set; } = new List<AttackStatistics>();

        public IEnumerable<DisciplineStatistics> DisciplineStatistics { get; set; } = new List<DisciplineStatistics>();

        public IEnumerable<MatchStatistics> MatchStatistics { get; set; } = new List<MatchStatistics>();

        public IEnumerable<FantasyUserPlayer> FantasyUserPlayers { get; set; } = new List<FantasyUserPlayer>();
    }
}
