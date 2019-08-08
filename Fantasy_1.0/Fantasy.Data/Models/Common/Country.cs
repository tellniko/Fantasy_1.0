using System.Collections.Generic;
using Fantasy.Data.Models.Players;

namespace Fantasy.Data.Models.Common
{
    public class Country : BaseModel<int>
    {
        public string Name { get; set; }

        public string FlagUrl { get; set; }

        //public IEnumerable<PlayerPersonalInfo> Countries { get; set; } = new List<PlayerPersonalInfo>();

        //public IEnumerable<PlayerPersonalInfo> BirthCountries { get; set; } = new List<PlayerPersonalInfo>();

    }
}
