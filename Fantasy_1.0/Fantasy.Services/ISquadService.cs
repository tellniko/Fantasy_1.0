using Fantasy.Data.Models.Game;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fantasy.Services.Models;

namespace Fantasy.Services
{
    public interface ISquadService
    {
        Task<List<FantasyPlayer>> GetSquadAsync(string id);

        Task<bool> ValidateSquadAsync(List<int> playerIds);

        Task<bool?> CreateSquadAsync(List<int> playerIds, string userId);

        Task<bool> ValidateFirstTeamAsync(string ids, string userId);

        Task<List<FantasyPlayer>> SaveFirstTeam(string ids, string userId);

        Task<List<FantasyPlayerServiceModel>> GetCurrentSquad(string userId, int gameweekId);

    }
}
