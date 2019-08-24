﻿using Fantasy.Data.Models.Common;

namespace Fantasy.Data.Models.Game
{
    public class GameweekStatus
    {
        public bool IsCaptain { get; set; }

        public bool IsBenched { get; set; }

        public int FantasyPlayerId { get; set; }
        public FantasyPlayer FantasyPlayer { get; set; }

        public int GameweekId { get; set; }
        public Gameweek Gameweek { get; set; }
    }
}
