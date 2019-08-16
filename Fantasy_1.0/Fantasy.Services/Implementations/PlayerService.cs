﻿using Fantasy.Common.Mapping;
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
            int page = 1, int 
                pageSize = 10)
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

        public async Task<bool> Edit(FootballPlayerServiceModel model)
        {
            var pl = await this.db.FootballPlayers.FindAsync(model.Id);

            var player = await this.db.FootballPlayers
                .Where(fp => fp.Id == model.Id)
                .Include(fp => fp.Info)
                .Include(fp => fp.FootballClub)
                .FirstOrDefaultAsync();

           if (player == null)
           {
               return false;
           }

           var test = model.To<FootballPlayer>();


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

          var result = await this.db.SaveChangesAsync();

          if (result != 1)
          {
              return false;
              //todo tempData
          }

           return true;
        }
    }
}