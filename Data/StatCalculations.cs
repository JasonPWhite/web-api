using System;
using System.Collections.Generic;
using System.Numerics;
using System.Globalization;
using System.Reflection;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.Models;
using System.Text.Json;
//using Newtonsoft.Json;
using System.Text.Json.Serialization;
using CsvHelper;

namespace web_api.Data
{
    public class StatCalculations : IStatCalculations
    {
        StatCalculations() { }
        private readonly DataContext _context;
        private List<RandomNumber> _randomNumbers;



        public StatCalculations(DataContext context)
        {
            _context = context;
            _randomNumbers = _context.RandomNumberList
                            .ToList();

            //TEST 1
            // _randomNumbers = new List<RandomNumber>();
            // _randomNumbers.Add(new RandomNumber(6));
            // _randomNumbers.Add(new RandomNumber(2));
            // _randomNumbers.Add(new RandomNumber(3));
            // _randomNumbers.Add(new RandomNumber(1));

            //TEST 2
            // _randomNumbers = new List<RandomNumber>();
            // _randomNumbers.Add(new RandomNumber(6));
            // _randomNumbers.Add(new RandomNumber(2));
            // _randomNumbers.Add(new RandomNumber(7));
            // _randomNumbers.Add(new RandomNumber(4));
            // _randomNumbers.Add(new RandomNumber(1));


            //TEST 3
            // _randomNumbers = new List<RandomNumber>();
            // _randomNumbers.Add(new RandomNumber(1));
            // _randomNumbers.Add(new RandomNumber(2));
            // _randomNumbers.Add(new RandomNumber(4));
            // _randomNumbers.Add(new RandomNumber(13));
            // _randomNumbers.Add(new RandomNumber(12));
            // _randomNumbers.Add(new RandomNumber(21));
            // _randomNumbers.Add(new RandomNumber(22));
            // _randomNumbers.Add(new RandomNumber(23));
            // _randomNumbers.Add(new RandomNumber(25));
            // _randomNumbers.Add(new RandomNumber(26));
            // _randomNumbers.Add(new RandomNumber(31));
            // _randomNumbers.Add(new RandomNumber(33));
            // _randomNumbers.Add(new RandomNumber(54));
            // _randomNumbers.Add(new RandomNumber(56));
            // _randomNumbers.Add(new RandomNumber(57));
            // _randomNumbers.Add(new RandomNumber(61.376));



        }

        public double CalculateMean()
        {
            double totalNum = 0;
            double sumNum = 0;

            foreach (var num in _randomNumbers)
            {
                sumNum += num.RandomNumb;
                totalNum++;
            }

            return sumNum / totalNum;
        }

        public double CalculateStdDev()
        {
            double mean = CalculateMean();
            double sumNum = 0;
            double totalNum = 0;
            double stdDiv = 0;

            foreach (var num in _randomNumbers)
            {
                sumNum += (Math.Abs(num.RandomNumb - mean) * Math.Abs(num.RandomNumb - mean));
                totalNum++;
            }

            stdDiv = Math.Sqrt(sumNum / totalNum);

            return stdDiv;
        }

        public string CalculateFrequencies()
        {
            var frequencies = new Dictionary<int, int>();

            foreach (var num in _randomNumbers)
            {
                int maxInt = (int)Math.Ceiling(num.RandomNumb);

                if (maxInt % 10 != 0) maxInt = (maxInt - maxInt % 10) + 10;

                int currentCount = 0;
                frequencies.TryGetValue(maxInt, out currentCount);
                frequencies[maxInt] = currentCount + 1;

            }

            var obj = new Dictionary<string, object>
            {
                ["id"] = 43,
                ["title"] = "Western Union",
                ["isEnabled"] = true,
                ["tags"] = new string[] { "things", "stuff" }
            };

            var json = JsonSerializer.Serialize(obj);

            var entries = frequencies.Select(d =>
                "{" + string.Format("\"range\":{0}, \"count\":{1}", d.Key, string.Join(",", d.Value)) + "}");
                return "[" + string.Join(",", entries) + "]";


        }

    }
}