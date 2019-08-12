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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            //var regex = new Regex("<span class=\"stat\">([A-Za-z\\ ]+)   <span.+\\s+([0-9\\.\\,]+)"); 

            //var properties = new Dictionary<string,string>();
            //var id = 5140;
            //var gameweekId = 1;

            //var responseFromServer = string.Empty;
            //var url = $"https://www.premierleague.com/players/5140/player/stats";
            //var request = WebRequest.Create(url);
            //request.Credentials = CredentialCache.DefaultCredentials;
            //var response = request.GetResponse();

            //using (var dataStream = response.GetResponseStream())
            //{
            //    var reader = new StreamReader(dataStream);
            //    responseFromServer = reader.ReadToEnd();

            //    foreach (Match match in regex.Matches(responseFromServer))
            //    {
            //        var key = match.Groups[1].ToString().Replace(" ", "");
            //        var value = match.Groups[2].ToString().Replace(",", "");

            //        if (!properties.ContainsKey(key))
            //        {
            //            properties.Add(key, value);
            //        }
            //    }


            //    foreach (var property in properties)
            //    {

            //        Console.WriteLine(property.Key + " -- " + property.Value);
            //    }

            //}
            //response.Close();
            //Console.WriteLine();

        }
    }
}
