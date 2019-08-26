using Fantasy.Common.Mapping;
using Fantasy.Data;
using Fantasy.Data.Models.FootballPlayers;
using Fantasy.Services.Administrator.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy.Services.Administrator.Implementations
{
    public class FootballPlayerService : IFootballPlayerService
    {
        private readonly FantasyDbContext db;

        public FootballPlayerService(FantasyDbContext db)
        {
            this.db = db;
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
            }

            return true;
        }

        public async Task<TModel> GetByIdAsync<TModel>(int id)
        {
            return await this.db.FootballPlayers
                .Where(p => p.Id == id)
                .To<TModel>()
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await this.db.FootballPlayers.FindAsync(id) != null;
        }
    }
}
