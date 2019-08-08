﻿using System;

namespace Fantasy.Data.Models.Common
{
    public class Fixture : BaseModel<int>
    {
        public DateTime? DateTimeStart { get; set; }

        public bool Finished { get; set; }

        public int HomeTeamId { get; set; }
        public FootballClub HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public FootballClub AwayTeam { get; set; }

        public int GameWeekId { get; set; }
        public Gameweek Gameweek { get; set; }
    }
}
