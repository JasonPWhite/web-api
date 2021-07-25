using System;
using System.Collections.Generic;
using System.IO;
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

namespace web_api.Data
{
    public class DbInitializer
    {

        private readonly DataContext _db;
        private readonly IWebHostEnvironment _env;
        public DbInitializer(DataContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public void Seed()
        {
            _db.Database.EnsureCreated();
            if (!_db.RandomNumberList.Any())
            {
                var Seeder = new RandomNumberSeeder(_db, _env);
                Seeder.Seed();
            }
        }
    }

}