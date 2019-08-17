using Fantasy.Services.Administrator.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Fantasy.Web.Areas.Administrator.Models
{
    public class FootballPlayerViewModel
    {
        public List<SelectListItem> Clubs { get; set; }

        public List<SelectListItem> Positions { get; set; }

        public FootballPlayerServiceModel Player { get; set; }
    }
}