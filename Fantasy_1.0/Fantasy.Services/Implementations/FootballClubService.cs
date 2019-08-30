using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fantasy.Services.Administrator.Models;

namespace Fantasy.Services.Implementations
{
    public class FootballClubService : IFootballClubService
    {
        private readonly FantasyDbContext db;

        public FootballClubService(FantasyDbContext db)
        {
            this.db = db;
        }

        public async Task<List<TModel>> GetAll<TModel>()
        {
            return await this.db.FootballClubs
                .OrderBy(fc => fc.Id)
                .To<TModel>()
                .ToListAsync();
        }

        public FootballClubDetailsServiceModel GetDetails(int id)
        {
            return  this.db.FootballClubs
                .Include(fc => fc.Squad)
                .ThenInclude(x =>x.Info)
                .Where(fc => fc.Id == id)
                .Select(fc => new FootballClubDetailsServiceModel
                {
                    Name = fc.Name,
                    Tag = fc.Tag,
                    Rating = fc.Rating,
                    BadgeImgUrl = fc.BadgeImgUrl,
                    Squad = fc.Squad
                        .Select(x => new FootballPlayerServiceModel
                    {
                        Id = x.Id,
                        InfoName = x.Info.Name,
                        InfoSmallImgUrl = x.Info.SmallImgUrl,
                        Price = x.Price,
                        PositionName = x.Position.Name,
                        InfoShirtNumber = x.Info.ShirtNumber,
                    }).ToList()
                })
                .FirstOrDefault();
        }
    }
}
