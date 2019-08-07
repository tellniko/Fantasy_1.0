using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fantasy.Common.Mapping;
using Fantasy.Services.Administrator.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fantasy.Web.Areas.Administrator.Models
{
    public class FixtureFormModel : IMapTo<FixtureServiceModel>
    {
        [Display(Name = "Home Team")]
        public int HomeTeamId { get; set; }

        [Display(Name = "Away Team")]
        public int AwayTeamId { get; set; }

        [Display(Name = "Start")]
        public DateTime DateTimeStart { get; set; }

        [Display(Name = "Gameweek")]
        public int GameweekId { get; set; }

        public bool Finished { get; set; }

        public IEnumerable<SelectListItem> FootballClubs { get; set; }

        public IEnumerable<SelectListItem> Gameweeks { get; set; }
    }
}
