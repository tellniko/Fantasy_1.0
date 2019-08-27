using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models.FootballPlayers;
using Fantasy.Data.Models.Statistics;
using Fantasy.Services.Administrator.Models;
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

        // todo refactor
        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>(string club, string position, string playerName, string order)
        {
            Expression<Func<FootballPlayer, bool>> filterCriteria =
                fp =>
                    fp.FootballClub.Tag.Contains(club ?? string.Empty)
                    && fp.FootballPlayerPosition.Name.Contains(position ?? string.Empty)
                    && fp.Info.Name.Contains(playerName ?? string.Empty);

            //todo refactor
            Expression<Func<FootballPlayer, string>> name = fp => fp.Info.Name;
            Expression<Func<FootballPlayer, decimal>> priceAscending = fp => fp.Price;
            Expression<Func<FootballPlayer, decimal>> priceDescending = fp => -fp.Price;

            var result = this.db.FootballPlayers
                .Where(filterCriteria);

            switch (order)
            {
                case "priceAscending":
                    result = result.OrderBy(priceAscending);
                    break;
                case "priceDescending":
                    result = result.OrderBy(priceDescending);
                    break;
                default:
                    result = result.OrderBy(name);
                    break;
            }

            return await result
                .Take(100)
                .To<TModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllWithPaginationAsync<TModel>(
            string club, 
            string position, 
            string playerName, 
            string order, 
            int page = 1, 
            int pageSize = 10)
        {

            playerName = playerName?.Replace("_", " ");

            Expression<Func<FootballPlayer, bool>> filterCriteria =
                fp =>
                    fp.FootballClub.Tag.Contains(club ?? string.Empty)
                    && fp.FootballPlayerPosition.Name.Contains(position ?? string.Empty)
                    && fp.Info.Name.Contains(playerName ?? string.Empty);

            //TODO: refactor
            Expression<Func<FootballPlayer, string>> name = fp => fp.Info.Name;
            Expression<Func<FootballPlayer, decimal>> priceAscending = fp => fp.Price;
            Expression<Func<FootballPlayer, decimal>> priceDescending = fp => -fp.Price;

            var result = this.db.FootballPlayers
                .Include(fp => fp.FootballClub)
                .Where(filterCriteria);

            switch (order)
            {
                case "priceAscending":
                    result = result.OrderBy(priceAscending);
                    break;
                case "priceDescending":
                    result = result.OrderBy(priceDescending);
                    break;
                default:
                    result = result.OrderBy(name);
                    break;
            }

            return await result
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .To<TModel>()
                .ToListAsync();
        }

        public async Task<TModel> GetByIdAsync<TModel>(int id)
        {
            return await this.db.FootballPlayers
                .Where(p => p.Id == id)
                .To<TModel>()
                .FirstOrDefaultAsync();
        }


        //todo statistics service
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
        

        public async Task<bool> Exists(int id)
        {
            return await this.db.FootballPlayers.FindAsync(id) != null;
        }
    }
}