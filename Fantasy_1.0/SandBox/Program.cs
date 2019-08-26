using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using Fantasy.Common.Attributes;
using Fantasy.Data;
using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.Statistics;
using Fantasy.Services.Models;
using Fantasy.Services.Models.Contracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Fantasy.Web.Infrastructure.Extensions;
using Console = System.Console;
using StringSplitOptions = System.StringSplitOptions;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var stat = new DefenderStatisticsServiceModel
            {
                MatchAppearances = 1,
                MatchWins = 1,
            };
            Console.WriteLine(typeof(short).Name);

            var properties = stat
                .GetType()
                .GetProperties()
                .Where(p => p.PropertyType.Name == typeof(short).Name)
                .ToList();



            foreach (var propertyInfo in properties)
            {
                Console.WriteLine(propertyInfo.PropertyType.Name
                                  + "  " + propertyInfo.GetValue(stat)
                                  + "   " + propertyInfo.GetCustomAttribute<PointsAttribute>().Units);
            }
           

            //var matchApps = properties.FirstOrDefault(x => x.Name == "MatchAppearances")
            //    ?.GetCustomAttribute<PointsAttribute>().Units;


            //foreach (var property in properties)
            //{
            //    var value = (short) property.GetValue(stat);
            //    var units = property.GetCustomAttribute<PointsAttribute>().Units;

            //    var result = value * units;
            //}


            Console.WriteLine();




        }
    }
}
