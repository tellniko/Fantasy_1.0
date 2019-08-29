namespace Fantasy.Data.Models
{
    public class GameweekPoints
    {
        public decimal Points { get; set; }

        public int FootbalPlayerId { get; set; }
        public FootballPlayer FootballPlayer { get; set; }

        public int GameweekId { get; set; }
        public Gameweek Gameweek { get; set; }
    }
}