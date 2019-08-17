using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.FootballPlayers;
using Newtonsoft.Json;

namespace Fantasy.Data.Models.Statistics
{
    public abstract class BaseStatistics
    {
        public int PlayerId { get; set; }
        [JsonIgnore]
        public FootballPlayer FootballPlayer { get; set; }

        public int GameweekId { get; set; }
        [JsonIgnore]
        public Gameweek Gameweek { get; set; }
    }
}
