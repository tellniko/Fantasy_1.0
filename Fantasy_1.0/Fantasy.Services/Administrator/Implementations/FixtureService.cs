﻿using System.Linq;
using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models.Common;
using Fantasy.Services.Administrator.Models;

namespace Fantasy.Services.Administrator.Implementations
{
    public class FixtureService : IFixtureService
    {
        private readonly FantasyDbContext db;

        public FixtureService(FantasyDbContext db)
        {
            this.db = db;
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
    }
}
