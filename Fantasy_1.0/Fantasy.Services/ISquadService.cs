using Fantasy.Data.Models.Game;
using Fantasy.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fantasy.Services
{
    public interface ISquadService
    {
        Task<List<FantasyPlayerServiceModel>> GetSquadAsync(string id);

        Task<bool> ValidateSquadAsync(List<int> playerIds);

        Task<bool?> CreateSquadAsync(List<int> playerIds, string userId);

        Task<bool> ValidateFirstTeamAsync(string ids, string userId);

        Task SaveFirstTeam(string ids, string userId);

        Task<List<FantasyPlayerServiceModel>> GetCurrentSquad(string userId, int gameweekId);

        Task<bool> SquadExists(string userId);

        Task Test(string useId);
    }
}
