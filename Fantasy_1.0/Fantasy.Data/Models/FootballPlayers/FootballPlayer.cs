using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.Game;
using Fantasy.Data.Models.Statistics;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fantasy.Data.Models.FootballPlayers
{
    public class FootballPlayer : BaseModel<int>
    {
        public bool IsInjured { get; set; } = false;

        public bool IsPlayable { get; set; } = true;

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public FootballPlayerInfo Info { get; set; }

        public int FootballPlayerPositionId { get; set; }
        public FootballPlayerPosition FootballPlayerPosition { get; set; }

        public int FootballClubId { get; set; }
        public FootballClub FootballClub { get; set; }

        public List<MatchStatistics> BaseStatistics { get; set; } = new List<MatchStatistics>();

        public List<GoalkeepingStatistics> GoalkeepingStatistics { get; set; } = new List<GoalkeepingStatistics>();

        public List<DefenceStatistics> DefenceStatistics { get; set; } = new List<DefenceStatistics>();

        public List<TeamPlayStatistics> TeamPlayStatistics { get; set; } = new List<TeamPlayStatistics>();

        public List<AttackStatistics> AttackStatistics { get; set; } = new List<AttackStatistics>();

        public List<DisciplineStatistics> DisciplineStatistics { get; set; } = new List<DisciplineStatistics>();

        public List<MatchStatistics> MatchStatistics { get; set; } = new List<MatchStatistics>();

        public List<FantasyUserPlayer> FantasyUserPlayers { get; set; } = new List<FantasyUserPlayer>();
    }
}
