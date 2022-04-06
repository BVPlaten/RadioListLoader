using Microsoft.EntityFrameworkCore;
using RadioDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioDb.DataAccess
{
    public class StationDb : DbContext
    {
        public DbSet<Country> CountryStations { get; set; }
        public DbSet<Station> RawHtmlData { get; set; }

        public string DbPath { get; }

        public StationDb()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            //DbPath = System.IO.Path.Join(path, "RadioStationDb.db");
            DbPath = @"D:\temp\RadioStations.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
