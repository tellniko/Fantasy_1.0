using System.Threading.Tasks;
using Fantasy.Services.Administrator.Models;

namespace Fantasy.Services.Administrator
{
    public interface IFootballPlayerService
    {
        Task<bool> Edit(FootballPlayerServiceModel model);

        bool Add(FootballPlayerServiceModel model);

        Task<TModel> GetByIdAsync<TModel>(int id);

        Task<bool> Exists(int id);
    }
}
