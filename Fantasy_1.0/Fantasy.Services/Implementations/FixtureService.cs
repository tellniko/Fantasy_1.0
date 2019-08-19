using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fantasy.Common.Mapping;
using Fantasy.Data;
using Microsoft.EntityFrameworkCore;

namespace Fantasy.Services.Implementations
{
    public class FixtureService : IFixtureService
    {
        private readonly FantasyDbContext db;

        public FixtureService(FantasyDbContext db)
        {
            this.db = db;
        }


        public async Task<IEnumerable<TModel>> GetByIdAsync<TModel>(int gameweekId)
        {
            var result = await this.db.Fixtures
                .Where(f => f.GameWeekId == gameweekId)
                .To<TModel>()
                .ToListAsync();

            return result;
        }
    }
}
