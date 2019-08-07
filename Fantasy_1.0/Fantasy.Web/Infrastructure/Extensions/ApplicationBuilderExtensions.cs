using Fantasy.Data;
using Fantasy.Data.Models.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    // or
                    //serviceScope.ServiceProvider.GetService<FantasyDbContext>().Database.Migrate();
                    
                    #region Seed Clubs
                    if (context.FootballClubs.FirstOrDefault(fc => fc.Name == "Arsenal") == null)
                    {
                        context.FootballClubs.AddRange(new List<FootballClub>
                        {
                            new FootballClub("AFC Bournemouth", "Bournemouth", "BOU"),
                            new FootballClub("Arsenal", "Arsenal", "ARS"),
                            new FootballClub("Aston Villa", "Aston Villa","AVL"),
                            new FootballClub("Brighton and Hove Albion", "Brighton","BRI"),
                            new FootballClub("Burnley", "Burnley","Bur"),
                            new FootballClub("Chelsea", "Chelsea","Che"),
                            new FootballClub("Crystal Palace", "Crystal Palace","CPA"),
                            new FootballClub("Everton", "Everton","EVE"),
                            new FootballClub("Leicester City", "Leicester","LEI"),
                            new FootballClub("Liverpool", "Liverpool","LIV"),
                            new FootballClub("Manchester City", "Man City","MAC"),
                            new FootballClub("Manchester United", "Man Utd","MAU"),
                            new FootballClub("Newcastle United", "Newcastle","NEW"),
                            new FootballClub("Norwich City", "Norwich","NOR"),
                            new FootballClub("Sheffield United", "Sheffield Utd","SHE"),
                            new FootballClub("Southampton", "Southampton","SOU"),
                            new FootballClub("Tottenham Hotspur", "Spurs","TOT"),
                            new FootballClub("Watford", "Watford","WAT"),
                            new FootballClub("West Ham United", "West Ham","WHU"),
                            new FootballClub("Wolverhampton Wanderers", "Wolves","WOL"),
                        });
                        context.SaveChanges();
                    }
                    #endregion

                    #region Administrator
                    var userManager = serviceScope.ServiceProvider.GetService<UserManager<FantasyUser>>();
                    var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                    // Allows a call of an async code in a sync context!
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
                    // or
                    //.Wait
                    #endregion

                    #region Seed Seasons
                    var season = new Season{Name = "2019-2020"};
                    context.Add(season);
                    context.SaveChanges();
                    #endregion

                    #region Seed Gameweeks
                    var gameweeks = new List<Gameweek>();
                    if (context.GameWeeks.ToList().Count == 0)
                    {
                        for (byte i = 0; i < 39; i++)
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


                }
            }

            return app;
        }
    }
}
