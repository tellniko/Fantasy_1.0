using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models.FootballPlayers;
using Fantasy.Data.Models.Statistics;
using Fantasy.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Remotion.Linq.Clauses;

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
                .OrderBy(fp => fp.Info.Name)
                .Take(100)
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
            return new StatisticsServiceModel
                {
                    Goalkeeping = await this.db.FindAsync<GoalkeepingStatistics>(playerId, gameweekId),
                    Discipline = await this.db.FindAsync<DisciplineStatistics>(playerId, gameweekId),
                    TeamPlay = await this.db.FindAsync<TeamPlayStatistics>(playerId, gameweekId),
                    Defence = await this.db.FindAsync<DefenceStatistics>(playerId, gameweekId),
                    Attack = await this.db.FindAsync<AttackStatistics>(playerId, gameweekId),
                    Match = await this.db.FindAsync<MatchStatistics>(playerId, gameweekId),
                }
                .To<TModel>();
        }
    }

    public class Test
    {
        public string name { get; set; }

        public DefenceStatistics DefenceStatistics { get; set; }

        public DisciplineStatistics DisciplineStatistics { get; set; }

        public AttackStatistics AttackStatistics { get; set; }


        public TeamPlayStatistics TeamPlayStatistics { get; set; }

        public GoalkeepingStatistics GoalkeepingStatistics { get; set; }
    }
}