namespace Fantasy.Services.Models
{
    public class FantasyPlayerServiceModel
    {
        public int Id { get; set; }

        public bool IsBenched { get; set; }

        public string BigImgUrl { get; set; }

        public string Name { get; set; }

        public int FootballPlayerId { get; set; }

        public string Position { get; set; }

        public string BadgeUrl { get; set; }
    }
}
