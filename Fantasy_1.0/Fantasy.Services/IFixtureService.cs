using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fantasy.Services
{
    public interface IFixtureService
    {
        Task<List<TModel>> GetByIdAsync<TModel>(int gameweekId);
    }
}
