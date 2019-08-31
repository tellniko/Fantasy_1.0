using Fantasy.Common;
using Fantasy.Services.Administrator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fantasy.Services.Models;

namespace Fantasy.Services
{
    using static GlobalConstants;

    public interface IFootballPlayerService
    {
        Task<bool> Edit(FootballPlayerFormModel model);

        int Add(FootballPlayerFormModel model);

        Task<TModel> GetByIdAsync<TModel>(int id);

        Task<bool> Exists(int id);

        Task<IEnumerable<TModel>> GetAllWithPaginationAsync<TModel>(
            string club,
            string position,
            string playerName,
            string order,
            int page = 1,
            int pageSize = PlayersListingPageSize);

        //Task<List<FootballPlayerShortServiceModel>> GetAllWithPaginationAsync(
        //    string club,
        //    string position,
        //    string playerName,
        //    string order,
        //    int page = 1,
        //    int pageSize = PlayersListingPageSize);

        Task<TModel> GetStatisticsAsync<TModel>(int playerId, int gameweekId);
    }
}
