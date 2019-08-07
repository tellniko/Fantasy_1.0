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
                            new FootballClub("AFC Bournemouth", "Bournemouth"),
                            new FootballClub("Arsenal", "Arsenal"),
                            new FootballClub("Aston Villa", "Aston Villa"),
                            new FootballClub("Brighton and Hove Albion", "Brighton"),
                            new FootballClub("Burnley", "Burnley"),
                            new FootballClub("Chelsea", "Chelsea"),
                            new FootballClub("Crystal Palace", "Crystal Palace"),
                            new FootballClub("Everton", "Everton"),
                            new FootballClub("Leicester City", "Leicester"),
                            new FootballClub("Liverpool", "Liverpool"),
                            new FootballClub("Manchester City", "Man City"),
                            new FootballClub("Manchester United", "Man Utd"),
                            new FootballClub("Newcastle United", "Newcastle"),
                            new FootballClub("Norwich City", "Norwich"),
                            new FootballClub("Sheffield United", "Sheffield Utd"),
                            new FootballClub("Southampton", "Southampton"),
                            new FootballClub("Tottenham Hotspur", "Spurs"),
                            new FootballClub("Watford", "Watford"),
                            new FootballClub("West Ham United", "West Ham"),
                            new FootballClub("Wolverhampton Wanderers", "Wolves"),
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

                    #region Seed Gameweeks
                    var gameweeks = new List<Gameweek>();
                    if (context.GameWeeks.ToList().Count == 0)
                    {
                        for (var i = 0; i < 39; i++)
                        {
                            var gameweek = new Gameweek
                            {
                                Number = i,
                                Start = DateTime.UtcNow.AddDays(30),
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
