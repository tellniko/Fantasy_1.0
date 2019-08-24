using Fantasy.Web.Infrastructure.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Fantasy.Web.Models
{
    //todo remove
    public class UserFirstTeamFormModel
    {
        public int PlayerId1 { get; set; }
        public int PlayerId2 { get; set; }
        public int PlayerId3 { get; set; }
        public int PlayerId4 { get; set; }
        public int PlayerId5 { get; set; }
        public int PlayerId6 { get; set; }
        public int PlayerId7 { get; set; }
        public int PlayerId8 { get; set; }
        public int PlayerId9 { get; set; }
        public int PlayerId10 { get; set; }
        public int PlayerId11 { get; set; }

        public List<int> GetPlayerIds()
        {
            var playerIds = new List<int>();

            this.GetType()
                .GetProperties()
                .ForEach(x => playerIds.Add((int)x.GetValue(this)));

            return playerIds.Distinct().ToList();
        }
    }
}