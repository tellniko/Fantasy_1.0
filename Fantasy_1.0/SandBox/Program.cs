using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.Players;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileContent = System.IO.File.ReadAllText("players.json");
            var players = JsonConvert.DeserializeObject<List<FootballPlayer>>(fileContent);

            Console.WriteLine();


        }

        public class FootballPlayer
        {
            public string Id { get; set; }

            public string FootballClubId { get; set; }
        }
    }
}
