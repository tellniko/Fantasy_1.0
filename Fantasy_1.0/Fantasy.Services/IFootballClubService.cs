using System.Collections.Generic;
using System.Threading.Tasks;
using Fantasy.Services.Models;

namespace Fantasy.Services
{
    public interface IFootballClubService
    {
        Task<List<TModel>> GetAll<TModel>();

        FootballClubDetailsServiceModel GetDetails(int id);

        List<FootballClubServiceModel> GetAll();
    }
}
