using Fantasy.Common;
using Fantasy.Data;
using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.Game;
using Fantasy.Services.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Fantasy.Services.Implementations
{
    using static GlobalConstants;

    public class SquadService : ISquadService
    {

        private readonly FantasyDbContext db;
        private readonly UserManager<FantasyUser> userManager;

        public SquadService(FantasyDbContext db, UserManager<FantasyUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        //todo refactor
        public async Task<List<FantasyPlayerServiceModel>> GetSquadAsync(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);

            return await this.db.FantasyPlayers
                .Where(fp => fp.FantasyUser == user)
                .Select(fp => new FantasyPlayerServiceModel
                {
                    Name = fp.FootballPlayer.Info.Name,
                    Position = fp.FootballPlayer.FootballPlayerPosition.Name,
                    BigImgUrl = fp.FootballPlayer.Info.BigImgUrl,
                    Id = fp.Id
                })
                .ToListAsync();
        }

        public async Task<bool> ValidateSquadAsync(List<int> playerIds)
        {
            var players = await this.db.FootballPlayers
                .Include(fp => fp.FootballPlayerPosition)
                .Where(fp => playerIds.Contains(fp.Id))
                .ToListAsync();

            if (players.Count != SquadPlayersCount
                || players.Count(fp => fp.FootballPlayerPosition.Name == Goalkeeper) != SquadGoalkeeperCount
                || players.Count(fp => fp.FootballPlayerPosition.Name == Defender) != SquadDefenderCount
                || players.Count(fp => fp.FootballPlayerPosition.Name == Midfielder) != SquadMidfielderCount
                || players.Count(fp => fp.FootballPlayerPosition.Name == Forward) != SquadForwardCount)
            {
                return false;
            }

            var footballClubs = new Dictionary<int,int>();
            foreach (var player in players)
            {
                if (!footballClubs.ContainsKey(player.FootballClubId))
                {
                    footballClubs.Add(player.FootballClubId, 0);
                }

                footballClubs[player.FootballClubId]++;
                if (footballClubs[player.FootballClubId] > PermittedPlayerFromSameClubCount)
                {
                    return false;
                }
            }

            if (players.Sum(fp => fp.Price) > SquadBudget)
            {
                return false;
            }

            return true;
        }

        public async Task<bool?> CreateSquadAsync(List<int> playerIds, string userId)
        {
            var fantasyUser = await this.userManager.FindByIdAsync(userId);
            if (fantasyUser == null)
            {
                return null;
            }
            var squad = new List<FantasyPlayer>();
            var scores = new List<GameweekScore>();

            var gameweeks = await this.db.Gameweeks.Take(SeasonGamewwekCount).ToListAsync();

            foreach (var playerId in playerIds)
            {
                var fantasyPlayer = new FantasyPlayer
                {
                    FootballPlayerId = playerId,
                    FantasyUser = fantasyUser,
                    GameweekStatuses = new List<GameweekStatus>(),
                };

                foreach (var gameweek in gameweeks)
                {
                    fantasyPlayer.GameweekStatuses.Add(new GameweekStatus
                    {
                        Gameweek = gameweek,
                        FantasyPlayer = fantasyPlayer,
                        IsCaptain = false,
                        IsBenched = true,
                    });
                }
                squad.Add(fantasyPlayer);
            }

            foreach (var gameweek in gameweeks) 
            {
                var score = new GameweekScore
                {
                    Gameweek = gameweek,
                    FantasyUser = fantasyUser,
                    Score = 0
                };
                scores.Add(score);
            }

            await this.db.AddRangeAsync(squad);
            await this.db.AddRangeAsync(scores);

            var result = await this.db.SaveChangesAsync();

            if (result == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> ValidateFirstTeamAsync(string ids, string userId)
        {
            if (ids == null)
            {
                return false;
            }

            var validInput = new Regex("^[0-9\\s]+$").Match(ids).Success;

            //validate input
            if (!validInput)
            {
                return false;
            }

            var idsList = ids.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .ToList();

            // validate count
            if (idsList.Count != 11)
            {
                return false;
            }

            var userSquadIds = await this.db.FantasyPlayers
                .Where(fp => fp.FantasyUserId == userId)
                .Select(fp => fp.Id)
                .ToListAsync();

            // validate ids
            foreach (var fantasyPlayerId in idsList)
            {
                if (!userSquadIds.Contains(fantasyPlayerId))
                {
                    return false;
                }
            }

            var validSystem = this.ValidateSystem(idsList);

            //validate system
            if (!validSystem)
            {
                return false;
            }

            Console.WriteLine();

            return true;
        }

        public async Task SaveFirstTeam(string ids, string userId)
        {
            var firstTeamIdsList = ids.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .ToList();

            var squad = this.db.FantasyPlayers
                .Include(fp => fp.GameweekStatuses)
                .ThenInclude(gs => gs.Gameweek)
                .Where(fp => fp.FantasyUserId == userId)
                .ToList();

            foreach (var player in squad)
            {
                foreach (var status in player.GameweekStatuses.Where(gws => gws.Gameweek.Start > DateTime.UtcNow))
                {
                    status.IsBenched = firstTeamIdsList.Contains(player.Id)
                        ? status.IsBenched = false
                        : status.IsBenched = true;
                }
            }

            await this.db.SaveChangesAsync();
        }

        public async Task<List<FantasyPlayerServiceModel>> GetCurrentSquad(string userId, int gameweekId)
        {
            var gameweek = await this.db.Gameweeks.FirstOrDefaultAsync(gw => gw.Id == gameweekId);
            var user = await this.userManager.FindByIdAsync(userId);

            return await this.db.FantasyPlayers
                .Where(fp => fp.FantasyUser == user)
                .Select(fp => new FantasyPlayerServiceModel
                {
                    Id = fp.Id,
                    IsBenched = fp.GameweekStatuses.FirstOrDefault(s => s.Gameweek == gameweek && s.FantasyPlayer == fp).IsBenched,
                    Name = fp.FootballPlayer.Info.Name,
                    BigImgUrl = fp.FootballPlayer.Info.BigImgUrl,
                    FootballPlayerId = fp.FootballPlayer.Id,
                    Position = fp.FootballPlayer.FootballPlayerPosition.Name,
                    BadgeUrl = fp.FootballPlayer.FootballClub.BadgeImgUrl
                })
                .ToListAsync();
        }

        public async Task<bool> SquadExists(string userId)
        {
            return await this.db.FantasyPlayers.Where(fp => fp.FantasyUserId == userId).CountAsync() != 0;
        }

        public async Task Test(string userId)
        {
            var gameweekId = 1;


            var gameweek = await this.db.Gameweeks.FirstOrDefaultAsync(gw => gw.Id == gameweekId);
            var user = await this.userManager.FindByIdAsync(userId);

            Console.WriteLine();

            var test = this.db.FantasyPlayers
                .Where(p => p.FantasyUser == user)
                .SelectMany(p => p.FootballPlayer.GameweekPoints.Where(gwp => gwp.Gameweek == gameweek))
                .Select(x => new
                {
                    id = x.FootbalPlayerId,
                    points = x.Points,
                    gameweekId = x.GameweekId,
                    fantasyplayerId = x.FootballPlayer.FantasyUserPlayers.Find(z => z.FootballPlayerId == x.FootbalPlayerId).Id

                })
                .ToList();

            Console.WriteLine();

            var mySquad = this.db.FantasyPlayers
                .Where(x => x.FantasyUser == user &&
                            x.GameweekStatuses.First(y => y.Gameweek == gameweek).IsBenched == false)

                .Sum(z => z.FootballPlayer.GameweekPoints.First(y => y.Gameweek == gameweek).Points);
               


            Console.WriteLine();
        }
        private bool ValidateSystem(List<int> idsList)
        {
            var firstTeamPositions = this.db.FantasyPlayers
                .Where(fp => idsList.Contains(fp.Id))
                .Select(fp => fp.FootballPlayer.FootballPlayerPosition.Name)
                .ToList();

            var goalkeepers = firstTeamPositions.Count(x => x == Goalkeeper);
            var defenders = firstTeamPositions.Count(x => x == Defender);
            var midfielders = firstTeamPositions.Count(x => x == Midfielder);
            var forwards = firstTeamPositions.Count(x => x == Forward);

            if (goalkeepers == 1 && defenders == 5 && midfielders == 4 && forwards == 1) return true;
            if (goalkeepers == 1 && defenders == 5 && midfielders == 3 && forwards == 2) return true;
            if (goalkeepers == 1 && defenders == 5 && midfielders == 2 && forwards == 3) return true;
            if (goalkeepers == 1 && defenders == 4 && midfielders == 5 && forwards == 1) return true;
            if (goalkeepers == 1 && defenders == 4 && midfielders == 4 && forwards == 2) return true;
            if (goalkeepers == 1 && defenders == 4 && midfielders == 3 && forwards == 3) return true;
            if (goalkeepers == 1 && defenders == 3 && midfielders == 5 && forwards == 2) return true;
            if (goalkeepers == 1 && defenders == 3 && midfielders == 4 && forwards == 3) return true;

            return false;
        }
    }
}
