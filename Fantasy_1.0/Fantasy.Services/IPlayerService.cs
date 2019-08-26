using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fantasy.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<TModel>> GetAllAsync<TModel>(
            string club,
            string position,
            string playerName,
            string order);

        Task<IEnumerable<TModel>> GetAllWithPaginationAsync<TModel>(
            string club, 
            string position, 
            string playerName, 
            string order, 
            int page = 1, 
            int pageSize = 10);

        Task<TModel> GetByIdAsync<TModel>(int id);

        Task<TModel> GetStatisticsAsync<TModel>(int playerId, int gameweekId);

        Task<bool> Exists(int id);
    }
}
