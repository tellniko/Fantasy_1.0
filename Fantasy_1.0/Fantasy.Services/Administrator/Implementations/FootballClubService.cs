using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Services.Administrator.Models;
using System.Collections.Generic;
using System.Linq;

namespace Fantasy.Services.Administrator.Implementations
{
    public class FootballClubService : IFootballClubService
    {
        private readonly FantasyDbContext db;

        public FootballClubService(FantasyDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<FootballClubServiceModel> GetAll()
        {
            return this.db
                .FootballClubs
                .OrderBy(fc => fc.Name)
                .To<FootballClubServiceModel>()
                .ToList();
        }
    }
}
