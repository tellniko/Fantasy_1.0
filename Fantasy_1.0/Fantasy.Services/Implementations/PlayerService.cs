using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models.FootballPlayers;
using Fantasy.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fantasy.Data.Models.Statistics;

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

        public async Task<TModel> GetStatisticsAsync<TModel>(int playerId, int gameweekId)
        {
            var goalkeeping = await this.db.FindAsync<GoalkeepingStatistics>(playerId, gameweekId);
            var defence = await this.db.FindAsync<DefenceStatistics>(playerId, gameweekId);
            var teamPlay = await this.db.FindAsync<TeamPlayStatistics>(playerId, gameweekId);
            var attack = await this.db.FindAsync<AttackStatistics>(playerId, gameweekId);
            var discipline = await this.db.FindAsync<DisciplineStatistics>(playerId, gameweekId);
            var match = await this.db.FindAsync<MatchStatistics>(playerId, gameweekId);
            
            var stat = new StatisticsServiceModel
            {
                Goalkeeping = goalkeeping,
                Defence = defence,
                TeamPlay = teamPlay,
                Attack = attack,
                Discipline = discipline,
                Match = match,
            };

            return stat.To<TModel>();
        }
    }
}


