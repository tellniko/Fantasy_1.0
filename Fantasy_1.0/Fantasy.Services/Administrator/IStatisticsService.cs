using System.Threading.Tasks;
using Fantasy.Services.Administrator.Models;

namespace Fantasy.Services.Administrator
{
    public interface IStatisticsService
    {
        string Seed(int gameweekId);

        Task<string> UpdateFootballPlayersPointsAsync(int gameweekId);

        Task<TModel> GetStatisticsAsync<TModel>(int playerId, int gameweekId);

        Task<int> EditPlayerStatisticsAsync(FootballPlayerStatisticsServiceModel model);
    }
}
