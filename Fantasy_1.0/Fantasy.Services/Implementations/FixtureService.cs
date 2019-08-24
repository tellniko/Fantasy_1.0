using Fantasy.Common.Mapping;
using Fantasy.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy.Services.Implementations
{
    public class FixtureService : IFixtureService
    {
        private readonly FantasyDbContext db;

        public FixtureService(FantasyDbContext db)
        {
            this.db = db;
        }

        public async Task<List<TModel>> GetByIdAsync<TModel>(int gameweekId)
        {
            return  await this.db.Fixtures
                .Where(f => f.GameWeekId == gameweekId)
                .To<TModel>()
                .ToListAsync();
        }
    }
}
