using System.Threading.Tasks;

namespace Fantasy.Services.Administrator
{
    public interface IStatisticsService
    {
        string Seed(int gameweekId);

        Task<string> UpdateFootballPlayersPoints(int gameweekId);

        Task<TModel> GetStatistics<TModel>(int playerId, int gameweekId);
    }
}
