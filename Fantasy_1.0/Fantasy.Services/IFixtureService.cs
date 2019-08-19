using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fantasy.Services
{
    public interface IFixtureService
    {
        Task<IEnumerable<TModel>> GetByIdAsync<TModel>(int gameweekId);
    }
}
