using Fantasy.Data;
using Fantasy.Data.Models.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fantasy.Data.Models.Players;

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
                        context.FootballClubs.Add(new FootballClub("AFC Bournemouth", "Bournemouth", "BOU")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("Arsenal", "Arsenal", "ARS")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("Aston Villa", "Aston Villa", "AVL")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("Brighton and Hove Albion", "Brighton", "BRI")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("Burnley", "Burnley", "BUR")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("Chelsea", "Chelsea", "CHE")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("Crystal Palace", "Crystal Palace", "CPA")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("Everton", "Everton", "EVE")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("Leicester City", "Leicester", "LEI")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("Liverpool", "Liverpool", "LIV")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("Manchester City", "Man City", "MAC")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("Manchester United", "Man Utd", "MAU")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("Newcastle United", "Newcastle", "NEW")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("Norwich City", "Norwich","NOR")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("Sheffield United", "Sheffield Utd", "SHE")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("Southampton", "Southampton", "SHU")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("Tottenham Hotspur", "Spurs", "TOT")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("Watford", "Watford", "WAT")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("West Ham United", "West Ham", "WHU")); context.SaveChanges();
                        context.FootballClubs.Add(new FootballClub("Wolverhampton Wanderers", "Wolves", "WOL")); context.SaveChanges();
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
                    
                    if (!context.GameWeeks.Any())
                    {
                        context.Add(new Gameweek { Number = 0, SeasonId = 1 });
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

                    #region Seed Positions
                    context.Add(new FootballPlayerPosition { Name = "Goalkeeper" }); context.SaveChanges();
                    context.Add(new FootballPlayerPosition { Name = "Defender" }); context.SaveChanges();
                    context.Add(new FootballPlayerPosition { Name = "Midfielder" }); context.SaveChanges();
                    context.Add(new FootballPlayerPosition { Name = "Forward" }); context.SaveChanges();
                    #endregion
                }
            }

            return app;
        }
    }
}
