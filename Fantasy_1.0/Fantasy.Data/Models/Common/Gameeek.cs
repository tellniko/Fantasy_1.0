using System;
using System.Collections.Generic;

namespace Fantasy.Data.Models.Common
{
    public class Gameweek : BaseModel<int>
    {
        public int Number { get; set; }

        public bool Finished { get; set; } = false;

        public DateTime Start { get; set; }

        public int SeasonId { get; set; }
        public Season Season { get; set; }

        public IEnumerable<Fixture> Fixtures { get; set; } = new List<Fixture>();
    }
}
