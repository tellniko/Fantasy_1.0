using Fantasy.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fantasy.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerServiceModel>> GetAllAsync(string club, string position);

        Task<PlayerDetailsServiceModel> GetByIdAsync(int id);
    }
}
