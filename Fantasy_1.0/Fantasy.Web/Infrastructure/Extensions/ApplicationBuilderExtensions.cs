using Fantasy.Data;
using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.FootballPlayers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fantasy.Common;

namespace Fantasy.Web.Infrastructure.Extensions
{
    using static GlobalConstants;
    using static DataConstants;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<FantasyDbContext>())
                {
                    //context.Database.Migrate();
                    // 
                    //serviceScope.ServiceProvider.GetService<FantasyDbContext>().Database.Migrate();

                    #region Administrator
                    var userManager = serviceScope.ServiceProvider.GetService<UserManager<FantasyUser>>();
                    var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                    // Allows a call of an async code in a sync context
                    Task.Run(async () =>
                        {
                            //todo refactor
                            var adminName = AdministratorRole;

                            var roleExists = await roleManager.RoleExistsAsync(adminName);
                            if (!roleExists)
                            {
                                await roleManager.CreateAsync(new IdentityRole
                                {
                                    Name = adminName
                                });
                            }

                            var adminEmail = "admin@admin.com";
                            var username = "admin";
                            var adminUser = await userManager.FindByNameAsync(username);

                            if (adminUser == null)
                            {
                                adminUser = new FantasyUser()
                                {
                                    Email = adminEmail,
                                    UserName = username,
                                    SquadName = "Cherno More",
                                };
                                await userManager.CreateAsync(adminUser, "123");
                                await userManager.AddToRoleAsync(adminUser, adminName);
                            }
                        })
                        .GetAwaiter()
                        .GetResult();
                    // 
                    //.Wait
                    #endregion
                    
                    #region Clubs
                    if (!context.FootballClubs.Any())
                    {
                        var clubs = new List<FootballClub>
                        {
                            new FootballClub
                            {
                                Id = 1,
                                Name = "AFC Bournemouth",
                                ShortName = "Bournemouth",
                                Tag = "BOU",
                                Rating = 2,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t91.svg",
                            },
                            new FootballClub
                            {
                                Id = 2,
                                Name = "Arsenal",
                                ShortName = "Arsenal",
                                Tag = "ARs",
                                Rating = 4,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t3.svg",
                            },
                            new FootballClub
                            {
                                Id = 3,
                                Name = "Aston Villa",
                                ShortName = "Aston Villa",
                                Tag = "AVL",
                                Rating = 1,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t7.svg"
                            },
                            new FootballClub
                            {
                                Id = 4,
                                Name = "Brighton and Hove Albion",
                                ShortName = "Brighton",
                                Tag = "BRI",
                                Rating = 1,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t36.svg"
                            },
                            new FootballClub
                            {
                                Id = 5,
                                Name = "Burnley",
                                ShortName = "Burnley",
                                Tag = "BUR",
                                Rating = 1,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t90.svg"
                            },
                            new FootballClub
                            {
                                Id = 6,
                                Name = "Chelsea",
                                ShortName = "Chelsea",
                                Tag = "CHE",
                                Rating = 4,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t8.svg"
                            },
                            new FootballClub
                            {
                                Id = 7,
                                Name = "Crystal Palace",
                                ShortName = "Crystal Palace",
                                Tag = "CPA",
                                Rating = 3,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t31.svg"
                            },
                            new FootballClub
                            {
                                Id = 8,
                                Name = "Everton",
                                ShortName = "Everton",
                                Tag = "EVE",
                                Rating = 3,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t11.svg"
                            },
                            new FootballClub
                            {
                                Id = 9,
                                Name = "Leicester City",
                                ShortName = "Leicester",
                                Tag = "LEI",
                                Rating = 3,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t13.svg"
                            },
                            new FootballClub
                            {
                                Id = 10,
                                Name = "Liverpool",
                                ShortName = "Liverpool",
                                Tag = "LIV",
                                Rating = 5,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t14.svg"
                            },
                            new FootballClub
                            {
                                Id = 11,
                                Name = "Manchester City",
                                ShortName = "Man City",
                                Tag = "MAC",
                                Rating = 5,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t43.svg"
                            },
                            new FootballClub
                            {
                                Id = 12,
                                Name = "Manchester United",
                                ShortName = "Man Utd",
                                Tag = "MAU",
                                Rating = 4,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t1.svg"
                            },
                            new FootballClub
                            {
                                Id = 13,
                                Name = "Newcastle United",
                                ShortName = "Newcastle",
                                Tag = "NEW",
                                Rating = 2,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t4.svg"
                            },
                            new FootballClub
                            {
                                Id = 14,
                                Name = "Norwich City",
                                ShortName = "Norwich",
                                Tag = "NOR",
                                Rating = 1,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t45.svg"
                            },
                            new FootballClub
                            {
                                Id = 15,
                                Name = "Sheffield United",
                                ShortName = "Sheffield Utd",
                                Tag = "SHE",
                                Rating = 1,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t49.svg"
                            },
                            new FootballClub
                            {
                                Id = 16,
                                Name = "Southampton",
                                ShortName = "Southampton",
                                Tag = "SHU",
                                Rating = 2,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t20.svg"
                            },
                            new FootballClub
                            {
                                Id = 17,
                                Name = "Tottenham Hotspur",
                                ShortName = "Spurs",
                                Tag = "TOT",
                                Rating = 4,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t6.svg"
                            },
                            new FootballClub
                            {
                                Id = 18,
                                Name = "Watford",
                                ShortName = "Watford",
                                Tag = "WAT",
                                Rating = 3,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t57.svg"
                            },
                            new FootballClub
                            {
                                Id = 19,
                                Name = "West Ham United",
                                ShortName = "West Ham",
                                Tag = "WHU",
                                Rating = 3,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t21.svg"
                            },
                            new FootballClub
                            {
                                Id = 20,
                                Name = "Wolverhampton Wanderers",
                                ShortName = "Wolves",
                                Tag = "WOL",
                                Rating = 3,
                                BadgeImgUrl =
                                    "https://premierleague-static-files.s3.amazonaws.com/premierleague/badges/t39.svg"
                            },
                        };

                        context.AddRange(clubs);
                        context.Database.OpenConnection();

                        try
                        {
                            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.FootballClubs ON");
                            context.SaveChanges();
                            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.FootballClubs OFF");
                        }
                        finally
                        {
                            context.Database.CloseConnection();
                        }
                    }
                    #endregion

                    #region Gameweeks
                    var gameweeks = new List<Gameweek>();

                    if (!context.Gameweeks.Any())
                    {
                        for (var i = 1; i <= 38; i++)
                        {
                            var gameweek = new Gameweek
                            {
                                Id = i,
                                Name = nameof(Gameweek) + " " + i,
                            };

                            gameweeks.Add(gameweek);
                        }

                        gameweeks.Add(new Gameweek { Id = PreSeasonStatisticsGameweekId, Name = "Pre Season" });
                        gameweeks.Add(new Gameweek { Id = AllTimeStatisticsGameweekId, Name = "All Time" });

                        context.AddRange(gameweeks);
                        context.Database.OpenConnection();

                        try
                        {
                            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Gameweeks ON");
                            context.SaveChanges();
                            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Gameweeks OFF");
                        }
                        finally
                        {
                            context.Database.CloseConnection();
                        }
                    }
                    #endregion

                    #region Fixtures
                    var fixtures = new List<Fixture>();
                    if (!context.Fixtures.Any())
                    {
                        var clubIds = new[]
                        {
                            10, 14, 19, 11, 1, 15, 5, 16, 7, 8, 9, 20, 18, 4, 17, 3, 13, 2, 12, 6, 2, 5, 3, 1, 4, 19, 6, 9, 8, 18,
                            11, 17, 14, 13, 15, 7, 16, 10, 20, 12, 1, 11, 3, 8, 4, 16, 10, 2, 12, 7, 14, 6, 15, 9, 17, 13, 18, 19,
                            20, 5, 2, 17, 5, 10, 6, 15, 7, 3, 8, 20, 9, 1, 11, 4, 13, 18, 16, 12, 19, 14, 1, 8, 3, 19, 4, 5, 10, 13,
                            12, 9, 14, 11, 15, 16, 17, 7, 18, 2, 20, 6, 2, 3, 5, 14, 6, 10, 7, 20, 8, 15, 9, 17, 11, 18, 13, 4, 16,
                            1, 19, 12, 1, 19, 3, 5, 6, 4, 7, 14, 8, 11, 9, 13, 12, 2, 15, 10, 17, 16, 20, 18, 2, 1, 4, 17, 5, 8, 10,
                            9, 11, 20, 13, 12, 14, 3, 16, 6, 18, 15, 19, 7, 1, 14, 3, 4, 6, 13, 7, 11, 8, 19, 9, 5, 12, 10, 15, 2,
                            17, 18, 20, 16, 2, 7, 4, 8, 5, 6, 10, 17, 11, 3, 13, 20, 14, 12, 16, 9, 18, 1, 19, 15, 1, 12, 2, 20, 3,
                            10, 4, 14, 7, 9, 8, 17, 11, 16, 15, 5, 18, 6, 19, 13, 5, 19, 6, 7, 9, 2, 10, 11, 12, 4, 13, 1, 14, 18,
                            16, 8, 17, 15, 20, 3, 1, 20, 2, 16, 3, 13, 4, 9, 7, 10, 8, 14, 11, 6, 15, 12, 18, 5, 19, 17, 5, 7, 6,
                            19, 9, 8, 10, 4, 12, 3, 13, 11, 14, 2, 16, 18, 17, 1, 20, 15, 2, 4, 5, 11, 9, 18, 15, 13, 20, 19, 12,
                            17, 6, 3, 16, 14, 7, 1, 10, 8, 1, 10, 3, 9, 4, 20, 8, 6, 11, 12, 13, 16, 14, 15, 17, 5, 18, 7, 19, 2, 2,
                            11, 5, 13, 6, 1, 7, 4, 9, 14, 10, 18, 12, 8, 15, 3, 16, 19, 20, 17, 1, 5, 3, 16, 4, 15, 8, 2, 11, 9, 13,
                            7, 14, 20, 17, 6, 18, 12, 19, 10, 1, 2, 3, 14, 6, 16, 7, 19, 8, 5, 9, 10, 12, 13, 15, 18, 17, 4, 20, 11,
                            2, 6, 4, 1, 5, 12, 10, 20, 11, 15, 13, 8, 14, 17, 16, 7, 18, 3, 19, 9, 2, 12, 4, 6, 5, 3, 10, 15, 11, 8,
                            13, 9, 14, 7, 16, 17, 18, 20, 19, 1, 1, 18, 3, 11, 6, 5, 7, 2, 8, 4, 9, 16, 12, 14, 15, 19, 17, 10, 20,
                            13, 2, 15, 4, 3, 5, 9, 10, 12, 11, 7, 13, 6, 14, 1, 16, 20, 18, 17, 19, 8, 1, 4, 3, 18, 8, 13, 9, 19,
                            15, 11, 20, 10, 12, 5, 6, 2, 17, 14, 7, 16, 1, 3, 5, 2, 7, 15, 9, 6, 10, 16, 12, 20, 13, 14, 17, 11, 18,
                            8, 19, 4, 2, 13, 3, 17, 4, 18, 6, 12, 8, 7, 11, 19, 14, 10, 15, 1, 16, 5, 20, 9, 2, 8, 5, 1, 6, 17, 7,
                            13, 9, 11, 10, 19, 12, 18, 15, 4, 16, 3, 20, 14, 1, 6, 3, 15, 4, 7, 8, 12, 11, 2, 13, 5, 14, 9, 17, 20,
                            18, 10, 19, 16, 2, 19, 5, 17, 6, 8, 7, 18, 9, 3, 10, 1, 12, 11, 15, 14, 16, 13, 20, 4, 1, 7, 3, 6, 4, 2,
                            8, 10, 11, 5, 13, 15, 14, 16, 17, 12, 18, 9, 19, 20, 5, 18, 6, 11, 9, 4, 10, 7, 12, 15, 13, 3, 14, 8,
                            16, 2, 17, 19, 20, 1, 1, 13, 2, 14, 3, 20, 4, 12, 7, 5, 8, 9, 11, 10, 15, 17, 18, 16, 19, 6, 5, 15, 6,
                            18, 9, 7, 10, 3, 12, 1, 13, 19, 14, 4, 16, 11, 17, 8, 20, 2, 1, 17, 2, 9, 3, 12, 4, 10, 7, 6, 8, 16, 11,
                            13, 15, 20, 18, 14, 19, 5, 1, 9, 3, 7, 4, 11, 10, 5, 12, 16, 14, 19, 15, 6, 17, 2, 18, 13, 20, 8, 2, 10,
                            5, 20, 6, 14, 7, 12, 8, 3, 9, 15, 11, 1, 13, 17, 16, 4, 19, 18, 1, 16, 3, 2, 4, 13, 10, 6, 12, 19, 14,
                            5, 15, 8, 17, 9, 18, 11, 20, 7, 2, 18, 5, 4, 6, 20, 7, 17, 8, 1, 9, 12, 11, 14, 13, 10, 16, 15, 19, 3,
                        };

                        var gameweekId = 1;
                        for (int i = 0; i < clubIds.Length; i += 2)
                        {
                            var fixture = new Fixture
                            {
                                HomeTeamId = clubIds[i],
                                AwayTeamId = clubIds[i + 1],
                                GameWeekId = gameweekId,
                            };
                            fixtures.Add(fixture);
                            if (fixtures.Count % 10 == 0)
                            {
                                gameweekId++;
                            }
                        }
                        context.AddRange(fixtures);
                        context.SaveChanges();
                    }
                    #endregion

                    #region Positions
                    if (!context.FootballPlayerPositions.Any())
                    {
                        context.Add(new FootballPlayerPosition { Name = Goalkeeper}); context.SaveChanges();
                        context.Add(new FootballPlayerPosition { Name = Defender }); context.SaveChanges();
                        context.Add(new FootballPlayerPosition { Name = Midfielder }); context.SaveChanges();
                        context.Add(new FootballPlayerPosition { Name = Forward }); context.SaveChanges();
                    }
                    #endregion
                }
            }

            return app;
        }
    }

}
