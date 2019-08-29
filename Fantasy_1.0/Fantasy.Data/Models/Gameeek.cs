using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fantasy.Data.Models
{
    public class Gameweek : BaseModel<int>
    {
        [MinLength(DataConstants.CommonNameMinLength)]
        [MaxLength(DataConstants.CommonNameMaxLength)]
        public string Name { get; set; }

        public bool Finished { get; set; } = false;

        public DateTime? Start { get; set; }

        public List<Fixture> Fixtures { get; set; } = new List<Fixture>();

        public List<GameweekStatistics> GameweekStatistics { get; set; } = new List<GameweekStatistics>();

        public List<GameweekStatus> GameweekStatuses { get; set; } = new List<GameweekStatus>();

        public List<GameweekPoints> GameweekPoints { get; set; } = new List<GameweekPoints>();

        public List<GameweekScore> GameweekScoreses { get; set; } = new List<GameweekScore>();
    }
}
