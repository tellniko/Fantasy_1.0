using System;
using System.Threading.Tasks;
using Fantasy.Data;

namespace Fantasy.Services.Implementations
{
    public class GameweekService : IGameweekService
    {
        private readonly FantasyDbContext db;

        public GameweekService(FantasyDbContext db)
        {
            this.db = db;
        }

        public async Task<DateTime?> GetStart(int gameweekId)
        {
            var gameweek = await this.db.Gameweeks.FindAsync(gameweekId);

            return gameweek.Start;
        }
    }
}
