using Fantasy.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fantasy.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<TModel>> GetAllAsync<TModel>(string club, string position, string playerName, string order);

        Task<TModel> GetByIdAsync<TModel>(int id);

        Task<TModel> GetStatisticsAsync<TModel>(int playerId, int gameweekId);
    }
}
