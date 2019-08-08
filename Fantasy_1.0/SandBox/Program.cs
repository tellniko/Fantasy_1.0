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
            var regex = new Regex("<span class=\"stat\">([A-Za-z\\ ]+)   <span.+\\s+([0-9\\.\\,]+)"); 

            var properties = new Dictionary<string,string>();
            var id = 5140;
            var gameweekId = 1;

            var responseFromServer = string.Empty;
            var url = $"https://www.premierleague.com/players/{id}/player/stats";
            var request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            var response = request.GetResponse();

            using (var dataStream = response.GetResponseStream())
            {
                var reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();

                foreach (Match match in regex.Matches(responseFromServer))
                {
                    var key = match.Groups[1].ToString().Replace(" ","");
                    var value = match.Groups[2].ToString().Replace(",","");

                    if (!properties.ContainsKey(key))
                    {
                        properties.Add(key, value);
                    }
                }

                var statistics = new List<BaseStatistics>
                {
                    new AttackStatistics(),
                    new MatchStatistics(),
                    new DefenceStatistics(),
                    new TeamPlayStatistics(),
                    new DisciplineStatistics(),
                    new GoalkeepingStatistics(),
                };

                foreach (var stat in statistics)
                {
                    stat.GameweekId = gameweekId;
                    stat.PlayerId = id;

                    foreach (var kvp in properties)
                    {
                        stat
                            .GetType()
                            .GetProperty(kvp.Key,
                                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                            ?.SetValue(stat, short.Parse(kvp.Value));
                    }
                }
            }
        }
    }
}
