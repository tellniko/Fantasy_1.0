using Fantasy.Services.Administrator.Models;
using Fantasy.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fantasy.Services
{
    public interface IFootballClubService
    {
        Task<List<TModel>> GetAll<TModel>();

        FootballClubDetailsServiceModel GetDetails(int id);
    }
}
