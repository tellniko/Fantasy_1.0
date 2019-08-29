using System;
using System.ComponentModel.DataAnnotations;

namespace Fantasy.Data.Models
{
    public class Fixture : BaseModel<int>
    {
        [Range(0, byte.MaxValue)]
        public byte Home { get; set; }

        [Range(0, byte.MaxValue)]
        public byte Away { get; set; }

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
