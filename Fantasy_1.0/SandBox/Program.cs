using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
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

            var test = " 1  2  4";

            var result = new Regex("^[0-9\\s]+$").Match(test).Success;

            Console.WriteLine(result);


            var list = test.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine();


        }
    }
}
