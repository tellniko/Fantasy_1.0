using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Fantasy.Data.Models.Common
{
    public class Season : BaseModel<int>
    {
        [Required]
        [RegularExpression("^\\d{4}\\-\\d{4}$")]
        public string Name { get; set; }

        public List<Gameweek> Gameweeks { get; set; } = new List<Gameweek>();
    }
}
