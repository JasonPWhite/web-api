using web_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace web_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<RandomNumber> RandomNumberList  { get; set; }
    }
}