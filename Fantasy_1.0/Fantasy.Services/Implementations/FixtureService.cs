﻿using Fantasy.Common.Mapping;
using Fantasy.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fantasy.Data.Models;
using Fantasy.Services.Administrator.Models;

namespace Fantasy.Services.Implementations
{
    public class FixtureService : IFixtureService
    {
        private readonly FantasyDbContext db;

        public FixtureService(FantasyDbContext db)
        {
            this.db = db;
        }

        public async Task<List<TModel>> GetByIdAsync<TModel>(int gameweekId)
        {
            return  await this.db.Fixtures
                .Where(f => f.GameWeekId == gameweekId)
                .To<TModel>()
                .ToListAsync();
        }

        public string Create(FixtureServiceModel model)
        {
            var fixture = model.To<Fixture>();

            var existingFixture = this.db.Fixtures
                .FirstOrDefault(f => f.HomeTeamId == fixture.HomeTeamId && f.AwayTeamId == fixture.AwayTeamId);

            if (existingFixture != null)
            {
                return "Fixture already exists!";
            }

            this.db.Add(fixture);
            this.db.SaveChanges();

            return null;
        }

        public IEnumerable<FixtureServiceModel> GetByGameweek(int id)
        {
            return this.db.Fixtures
                .Where(f => f.GameWeekId == id)
                .To<FixtureServiceModel>()
                .ToList();
        }
    }
}
