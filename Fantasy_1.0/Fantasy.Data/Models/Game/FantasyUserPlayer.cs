using Fantasy.Data.Models.FootballPlayers;

namespace Fantasy.Data.Models.Game
{
    public class FantasyUserPlayer : BaseModel<int>
    {
        public bool IsFirstTeam { get; set; }

        public int FootballPlayerId { get; set; }
        public FootballPlayer FootballPlayer { get; set; }
    }
}
