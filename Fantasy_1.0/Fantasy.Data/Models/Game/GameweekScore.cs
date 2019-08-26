using Fantasy.Data.Models.Common;

namespace Fantasy.Data.Models.Game
{
    public class GameweekScore
    {
        public string FantasyUserId { get; set; }
        public FantasyUser FantasyUser { get; set; }

        public int GameweekId { get; set; }
        public Gameweek Gameweek { get; set; }

        public decimal Score { get; set; }
    }
}