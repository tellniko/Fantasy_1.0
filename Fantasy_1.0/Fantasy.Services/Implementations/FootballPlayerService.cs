using Fantasy.Common;
using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models;
using Fantasy.Services.Administrator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fantasy.Services.Implementations
{
    using static GlobalConstants;
    public class FootballPlayerService : IFootballPlayerService
    {
        private readonly FantasyDbContext db;

        public FootballPlayerService(FantasyDbContext db)
        {
            this.db = db;
        }
      
        public async Task<IEnumerable<TModel>> GetAllWithPaginationAsync<TModel>(
            string club, 
            string position, 
            string playerName, 
            string order, 
            int page = 1, 
            int pageSize = PlayersListingPageSize)
        {
            playerName = playerName?.Replace("_", " ");

            Expression<Func<FootballPlayer, bool>> filterCriteria =
                fp =>
                    fp.FootballClub.Tag.Contains(club ?? string.Empty)
                    && fp.Position.Name.Contains(position ?? string.Empty)
                    && fp.Info.Name.ToLower().Contains(playerName ?? string.Empty)
                    && fp.IsPlayable;

            //TODO: refactor
            Expression<Func<FootballPlayer, string>> name = fp => fp.Info.Name;
            Expression<Func<FootballPlayer, decimal>> priceAscending = fp => fp.Price;
            Expression<Func<FootballPlayer, decimal>> priceDescending = fp => -fp.Price;
            Expression<Func<FootballPlayer, decimal>> totalPoints = fp => -fp.GameweekPoints.Sum(x => x.Points);

            var result = this.db.FootballPlayers
                .Include(fp => fp.FootballClub)
                .Include(fp => fp.GameweekPoints)
                .Where(filterCriteria);

            switch (order)
            {
                case "priceAscending":
                    result = result.OrderBy(priceAscending);
                    break;
                case "priceDescending":
                    result = result.OrderBy(priceDescending);
                    break;
                case "name":
                    result = result = result.OrderBy(name);
                    break;
                default:
                    result = result.OrderBy(totalPoints);
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

        public int Add(FootballPlayerFormModel model)
        {
            var result = 0;

            var player = model.To<FootballPlayer>();
            var info = new FootballPlayerInfo();

            player.Info = info;
            info.Name = model.InfoName;
            info.BigImgUrl = model.InfoBigImgUrl;
            info.SmallImgUrl = model.InfoSmallImgUrl;
            info.Country = model.InfoCountry;
            info.FootballPlayer = player;
            info.Height = model.InfoHeight;
            info.Weight = model.InfoWeight;
            info.ShirtNumber = model.InfoShirtNumber;
            info.BirthDate = model.InfoBirthDate;
            info.JoinDate = model.InfoJoinDate;
            info.BirthPlace = model.InfoBirthPlace;

            for (int i = 1; i <= 38; i++)
            {
                player.GameweekPoints.Add(new GameweekPoints
                {
                    GameweekId = i,
                    Points = 0,
                });
                
            }
            for (int i = 1; i <= 40; i++)
            {
                player.GameweekStatistics.Add(new GameweekStatistics
                {
                    GameweekId = i,
                });
            }

            db.Add(player);
            db.Add(info);

            db.Database.OpenConnection();
            try
            {
                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.FootballPlayers ON");
                result = db.SaveChanges();
                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.FootballPlayers OFF");
            }
            finally
            {
                db.Database.CloseConnection();
            }

            return result;
        }

        //todo refactor
        public async Task<bool> Edit(FootballPlayerFormModel model)
        {
            var player = await this.db.FootballPlayers
                .Where(fp => fp.Id == model.Id)
                .Include(fp => fp.Info)
                .Include(fp => fp.FootballClub)
                .FirstOrDefaultAsync();

            player.FootballClubId = model.FootballClubId;
            player.Info.BigImgUrl = model.InfoBigImgUrl;
            player.Info.SmallImgUrl = model.InfoSmallImgUrl;
            player.Info.ShirtNumber = model.InfoShirtNumber;
            player.Info.Country = model.InfoCountry;
            player.Info.BirthDate = model.InfoBirthDate;
            player.Info.JoinDate = model.InfoJoinDate;
            player.Info.Name = model.InfoName;
            player.Info.BirthPlace = model.InfoBirthPlace;
            player.Info.Weight = model.InfoWeight;
            player.Info.Height = model.InfoHeight;
            player.IsPlayable = model.IsPlayable;
            player.IsInjured = model.IsInjured;
            player.FootballPlayerPositionId = model.FootballPlayerPositionId;

            var result = await this.db.SaveChangesAsync();

            if (result == 0)
            {
                return false;
            }

            return true;
        }
    }
}