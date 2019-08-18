using Fantasy.Data;
using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.FootballPlayers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Fantasy.Web.Infrastructure.Extensions
{
    using static GlobalConstants;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<FantasyDbContext>())
                {
                    //context.Database.Migrate();
                    // 
                    //serviceScope.ServiceProvider.GetService<FantasyDbContext>().Database.Migrate();
                    
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
                                ShortName = "Spurs",
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
                            {
                                context.Database.CloseConnection();
                            }
                        }
                    }
                    #endregion

                    #region Administrator
                    var userManager = serviceScope.ServiceProvider.GetService<UserManager<FantasyUser>>();
                    var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                    // Allows a call of an async code in a sync context
                    Task.Run(async () =>
                        {
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
                                    FullName = username,
                                    SquadName = username,
                                    FootballClubId = 1,
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

                    #region Seasons
                    var season = new Season { Name = "2019-2020" };
                    context.Add(season);
                    context.SaveChanges();
                    #endregion

                    #region Gameweeks
                    var gameweeks = new List<Gameweek>();
                    
                    if (!context.GameWeeks.Any())
                    {
                        context.Add(new Gameweek { Number = 0, SeasonId = 1 });
                        context.SaveChanges();
                        context.Add(new Gameweek { Number = 39, SeasonId = 1 });
                        context.SaveChanges();

                        for (byte i = 1; i <= 38; i++)
                        {
                            var gameweek = new Gameweek
                            {
                                Number = i,
                                SeasonId = 1,
                            };
                            gameweeks.Add(gameweek);
                        }

                        context.AddRange(gameweeks);
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
