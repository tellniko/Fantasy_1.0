using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models;
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
                    && fp.Position.Name.Contains(position ?? string.Empty)
                    && fp.Info.Name.Contains(playerName ?? string.Empty)
                    && fp.IsPlayable;

            //TODO: refactor
            Expression<Func<FootballPlayer, string>> name = fp => fp.Info.Name;
            Expression<Func<FootballPlayer, decimal>> priceAscending = fp => fp.Price;
            Expression<Func<FootballPlayer, decimal>> priceDescending = fp => -fp.Price;
            Expression<Func<FootballPlayer, decimal>> totalPoints = fp => -fp.GameweekPoints.Sum(x => x.Points);

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
                case "totalPoints":
                    result = result.OrderBy(totalPoints);
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

        public async Task<TModel> GetStatisticsAsync<TModel>(int playerId, int gameweekId)
        {
            var player = await this.db.FindAsync<FootballPlayer>(playerId);
            var gameweek = await this.db.FindAsync<Gameweek>(gameweekId);

            return await this.db.GameweekStatistics
                .Where(x =>x.Gameweek == gameweek && x.FootballPlayer == player)
                .To<TModel>()
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await this.db.FootballPlayers.FindAsync(id) != null;
        }
    }
}