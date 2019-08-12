using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models.FootballPlayers;
using Fantasy.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fantasy.Services.Implementations
{
    public class PlayerService : IPlayerService
    {
        private readonly FantasyDbContext db;

        public PlayerService(FantasyDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<PlayerServiceModel>> GetAllAsync(string club, string position)
        {
            Expression<Func<FootballPlayer, bool>> filterCriteria =
                fp => fp.FootballClub.Tag.Contains(club ?? string.Empty) 
                      && fp.FootballPlayerPosition.Name.Contains(position ?? string.Empty);

            return await this.db.FootballPlayers
                .Where(filterCriteria)
                .OrderBy(fp => fp.FootballPlayerPositionId)
                .ThenBy(fp => fp.Info.Name)
               // .Take(25)
                .To<PlayerServiceModel>()
                .ToListAsync();
        }

        public async Task<PlayerDetailsServiceModel> GetByIdAsync(int id)
        {
            return await this.db.FootballPlayers
                .Where(p => p.Id == id)
                .To<PlayerDetailsServiceModel>()
                .FirstOrDefaultAsync();
        }
    }
}
