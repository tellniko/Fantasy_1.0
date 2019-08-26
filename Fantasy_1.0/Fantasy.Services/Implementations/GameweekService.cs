using System;
using System.Linq;
using System.Threading.Tasks;
using Fantasy.Data;
using Fantasy.Data.Models.Common;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Gameweek> GetLast(DateTime? date)
        {
            var gameweek = await this.db.Gameweeks
                .OrderByDescending(gw => gw.Start)
                .FirstOrDefaultAsync(gw => gw.Start < date);

            return gameweek;
        }

        public async Task<Gameweek> GetNext(DateTime? date)
        {
            var gameweek = await this.db.Gameweeks
                .OrderBy(gw => gw.Start)
                .FirstOrDefaultAsync(gw => gw.Start > date);

            return gameweek;
        }
    }
}
