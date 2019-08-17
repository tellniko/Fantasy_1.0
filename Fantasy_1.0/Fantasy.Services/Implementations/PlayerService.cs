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

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>(string club, string position, string playerName, string order)
        {
            Expression<Func<FootballPlayer, bool>> filterCriteria =
                fp =>
                    fp.FootballClub.Tag.Contains(club ?? string.Empty)
                    && fp.FootballPlayerPosition.Name.Contains(position ?? string.Empty)
                    && fp.Info.Name.Contains(playerName ?? string.Empty);

            //TODO: Generic
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
            Expression<Func<FootballPlayer, bool>> filterCriteria =
                fp =>
                    fp.FootballClub.Tag.Contains(club ?? string.Empty)
                    && fp.FootballPlayerPosition.Name.Contains(position ?? string.Empty)
                    && fp.Info.Name.Contains(playerName ?? string.Empty);

            //TODO: Generic
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

        //todo refactor
        public async Task<bool> Edit(FootballPlayerServiceModel model)
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
              //todo tempData
          }

           return true;
        }

        //todo refactor
        public bool Add(FootballPlayerServiceModel model)
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

            if (result == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Exists(int id)
        {
            return await this.db.FootballPlayers.FindAsync(id) != null;
        }
    }
}