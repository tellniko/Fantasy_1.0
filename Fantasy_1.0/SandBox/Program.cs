using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using Fantasy.Common.Attributes;
using Fantasy.Data;
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
            var a = new List<IHaveMatchStatistics>();
            IHaveMatchStatistics b = new DefenderStatisticsServiceModel();

            a.Add(new DefenderStatisticsServiceModel());
            a.Add(new GoalkeeperStatisticsServiceModel());


            b
                .GetType()
                .GetProperties()
                .Where(p => p.PropertyType == typeof(short))
                .ToList()
                .ForEach(x => Console.WriteLine(x.Name));
        }
    }
}
