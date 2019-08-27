using Fantasy.Web.Infrastructure.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Fantasy.Web.Models
{
    public class UserSquadFormModel
    {
        [Range(1, int.MaxValue)]
        public int PlayerId1 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId2 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId3 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId4 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId5 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId6 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId7 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId8 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId9 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId10 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId11 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId12 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId13 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId14 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId15 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId16 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId17 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId18 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId19 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId20 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId21 { get; set; }
        [Range(1, int.MaxValue)]
        public int PlayerId22 { get; set; }

        public List<int> GetPlayerIds()
        {
            var playerIds = new List<int>();

            this.GetType()
                .GetProperties()
                .ForEach(x => playerIds.Add((int) x.GetValue(this)));
            
            return playerIds.Distinct().ToList();
        }
    }
}