using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models;
using Fantasy.Services.Administrator.Models;
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

        public List<TModel> GetAll<TModel>()
        {
            return this.db.Gameweeks
                .Take(38)
                .To<TModel>()
                .ToList();
        }

        public TModel GetById<TModel>(int gameweekId)
        {
            return this.db.Gameweeks
                .Where(gw => gw.Id == gameweekId)
                .To<TModel>()
                .FirstOrDefault();
        }

        public bool? Edit(GameweekServiceModel model)
        {
            var gameweek = this.db.Gameweeks.Find(model.Id);
            if (gameweek == null)
            {
                return null;
            }

            gameweek.Finished = model.Finished;
            gameweek.Start = model.Start;

            var result = this.db.SaveChanges();
            if (result == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<Gameweek> GetByStart(DateTime start)
        {
            var a = await this.db.Gameweeks
                .Include(gw => gw.Fixtures)
                .Include(gw => gw.GameweekStatuses).ToListAsync();

            return null;
        }
    }
}
