using System;
using System.Linq;
using System.Text.RegularExpressions;
using Fantasy.Data.Models.Common;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllText(@"fixtures.txt")
                .Split(new []{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Console.WriteLine();

            
        }
    }
}
