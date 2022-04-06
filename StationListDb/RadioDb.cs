using RadioDb.DataAccess;
using RadioDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioDb
{
    public class RadioDb
    {
        public StationDb db;

        public RadioDb()
        {
            db = new StationDb();
            DeleteRows(db);
            db.SaveChanges();
        }

        protected static void DeleteRows(StationDb db)
        {
            Console.WriteLine("deleting all entries in the database:");
            IQueryable<Country>? rowsCS = from o in db.CountryStations select o;
            foreach (var r in rowsCS)
            {
                db.CountryStations.Remove(r);
            }

            IQueryable<Station>? rowRHT = from o in db.RawHtmlData select o;
            foreach (var r in rowRHT)
            {
                db.RawHtmlData.Remove(r);
            }
        }

        /// <summary>
        /// AddCountry : add a country with main url in db
        /// </summary>
        /// <param name="cs"></param>
        public void AddCountry(Country cs)
        {
            db.Add(cs);
        }

        /// <summary>
        /// AddHtmlSource : add a new html page with the raw source data
        /// </summary>
        /// <param name="rd"></param>
        public void AddHtmlSource(Station rd)
        {
            db.Add(rd);
        }


    }
}
