using System;
using System.Collections.Generic;
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
using System.Text.Json.Serialization;
using CsvHelper;

namespace web_api.Data
{
    public class RandomNumberSeeder
    {
        private readonly DataContext _db;
        private readonly IWebHostEnvironment _env;
        public RandomNumberSeeder(DataContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public void Seed()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            string rootPath = _env.ContentRootPath;

            string resourceName = Path.GetFullPath(Path.Combine(rootPath, "Data", "SampleData.csv")); 


                using (StreamReader reader = new StreamReader(resourceName))
                {
                    string line = reader.ReadLine();


                    List<string> records = line.Split(',').ToList<string>();

     
                        foreach (var item in records)
                        {
                            var n = new RandomNumber(double.Parse(item));
                            _db.RandomNumberList.Add(n);
                        }
                        _db.SaveChanges();


                }
            
        }
    }
}