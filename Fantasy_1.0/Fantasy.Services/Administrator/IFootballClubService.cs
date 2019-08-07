using System.Collections.Generic;
using Fantasy.Services.Administrator.Models;

namespace Fantasy.Services.Administrator
{
    public interface IFootballClubService
    {
        IEnumerable<FootballClubServiceModel> GetAll();
    }
}
