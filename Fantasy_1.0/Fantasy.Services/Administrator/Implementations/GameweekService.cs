using System.Collections.Generic;
using System.Linq;
using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models.Common;
using Fantasy.Services.Administrator.Models;

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

        public bool Edit(GameweekServiceModel model)
        {
            db.Update(model.To<Gameweek>());

            return  db.SaveChanges() == 1;
        }
    }
}
