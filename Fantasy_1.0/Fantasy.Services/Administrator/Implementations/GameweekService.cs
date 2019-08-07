using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models.Common;
using Fantasy.Services.Administrator.Models;
using Microsoft.EntityFrameworkCore;

namespace Fantasy.Services.Administrator.Implementations
{
    public class GameweekService : IGameweekService
    {
        private readonly FantasyDbContext db;

        public GameweekService(FantasyDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<GameweekServiceModel> GetAll()
        {
            return this.db
                .GameWeeks
                .Where(gw => gw.Number != 0)
                .OrderBy(gw => gw.Number)
                .To<GameweekServiceModel>()
                .ToList();
        }

        public GameweekServiceModel Get(int id)
        {
            return this.db
                .GameWeeks
                .Where(gw => gw.Id == id)
                .To<GameweekServiceModel>()
                .FirstOrDefault();
        }

        //public GameweekDetailsServiceModel GetDetails(int id)
        //{
        //    return this.db.GameWeeks
        //        .Where(gw => gw.Id == id)
        //        .Select(gw => new GameweekDetailsServiceModel
        //        {
        //            Gameweek = new GameweekServiceModel
        //            {
        //                Id = gw.Id,
        //                Number = gw.Number,
        //                Finished = gw.Finished,
        //                Start = gw.Start
        //            },
        //            Fixtures = gw.Fixtures
        //            .Select(f => new FixtureServiceModel
        //            {
        //                AwayTeamId = f.AwayTeamId,
        //                HomeTeamId = f.HomeTeamId,
        //                DateTimeStart = f.DateTimeStart,
        //                Finished = f.Finished,
        //                GameweekId = id,
        //            })
        //           .ToList()
        //        })
        //        .FirstOrDefault();
        //}

        public bool Edit(GameweekServiceModel model)
        {
            var gw = this.db.GameWeeks.Find(model.Id);

            if (gw == null)
            {
                return false;
            }

            gw.Finished = model.Finished;
            gw.Start = model.Start;

            db.Update(gw);

            return  db.SaveChanges() == 1;
        }
    }
}
