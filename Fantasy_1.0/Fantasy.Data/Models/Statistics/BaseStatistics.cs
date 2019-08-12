using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.FootballPlayers;

namespace Fantasy.Data.Models.Statistics
{
    public abstract class BaseStatistics
    {
        public int PlayerId { get; set; }
        public FootballPlayer FootballPlayer { get; set; }

        public int GameweekId { get; set; }
        public Gameweek Gameweek { get; set; }
    }
}
