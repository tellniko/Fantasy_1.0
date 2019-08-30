using Fantasy.Services.Administrator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fantasy.Services
{
    public interface IFixtureService
    {
        Task<List<TModel>> GetByIdAsync<TModel>(int gameweekId);

        string Create(FixtureServiceModel model);

        IEnumerable<FixtureServiceModel> GetByGameweek(int id);
    }
}
