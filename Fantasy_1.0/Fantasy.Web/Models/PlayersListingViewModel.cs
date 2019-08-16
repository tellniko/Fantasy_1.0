using System.Collections.Generic;
using Fantasy.Services.Models;

namespace Fantasy.Web.Models
{
    public class PlayersListingViewModel : PageListingViewModel
    {
        public IEnumerable<PlayerServiceModel> Players { get; set; }
    }
}
