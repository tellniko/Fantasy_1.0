using Fantasy.Services.Administrator.Models;
using System.Threading.Tasks;

namespace Fantasy.Services.Administrator
{
    public interface IStatisticsService
    {
        string Seed(int gameweekId);

        Task<int> UpdateFootballPlayersPointsAsync(int gameweekId);

        Task<TModel> GetStatisticsAsync<TModel>(int playerId, int gameweekId);

        Task<int> EditPlayerStatisticsAsync(FootballPlayerStatisticsServiceModel model);
    }
}
