using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using Fantasy.Data;
using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.Players;
using Fantasy.Data.Models.Statistics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {

            var regex =new Regex("<span class=\"stat\">([A-Za-z\\ ]+)   <span.+\\s+([0-9\\.\\,]+)"); 

            var dict = new Dictionary<string,string>();
            var id = 5140;
            var fixtureId = 1;

            var responseFromServer = string.Empty;
            var url = $"https://www.premierleague.com/players/{id}/player/stats";
            var request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            var response = request.GetResponse();

            using (var dataStream = response.GetResponseStream())
            {
                var reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();

                var matches = regex.Matches(responseFromServer);
                foreach (Match match in matches)
                {
                    var key = match.Groups[1].ToString().Replace(" ","");
                    var value = match.Groups[2].ToString().Replace(",","");
                    if (!dict.ContainsKey(key))
                    {
                        dict.Add(key, value);
                    }
                }

                var attackStat = new AttackStatistics();
                var baseStat = new MatchStatistics();
                var defenceStat = new DefenceStatistics();
                var teamPlayStat = new TeamPlayStatistics();
                var disciplineStat = new DisciplineStatistics();
                var goalkeeperStat = new GoalkeepingStatistics();

                foreach (var kvp in dict)
                {
                  
                    baseStat
                        .GetType()
                        .GetProperty(kvp.Key, 
                            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        ?.SetValue(baseStat, short.Parse(kvp.Value));

                    goalkeeperStat
                        .GetType()
                        .GetProperty(kvp.Key,
                            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        ?.SetValue(goalkeeperStat, short.Parse(kvp.Value));

                    defenceStat
                        .GetType()
                        .GetProperty(kvp.Key,
                            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        ?.SetValue(defenceStat, short.Parse(kvp.Value));

                    attackStat
                        .GetType()
                        .GetProperty(kvp.Key,
                            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        ?.SetValue(attackStat, short.Parse(kvp.Value));

                    teamPlayStat
                        .GetType()
                        .GetProperty(kvp.Key,
                            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        ?.SetValue(teamPlayStat, short.Parse(kvp.Value));
                }




                foreach (var kvp in dict)
                {
                    Console.WriteLine(kvp.Key + "  -  " + kvp.Value);
                }
            }

            Console.WriteLine();
        }
    }
}
