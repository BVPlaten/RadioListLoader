using RadioDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioDb
{
    /*
     * CountryData : read the country-list from a given webside 
     *               load from file or get over http-request
     * 
     * */
    public class CountryData : List<Country>
    {
        // public List<string> urlLst = new List<string>();

        public CountryData(string toLoad )
        {
            //string[] lines = LoadFile(toLoad);
            string[] lines = LoadWebSite(toLoad);

            foreach (var l in lines)
            {
                if (l.StartsWith("<br>") && l.Contains("flagsitu"))
                {
                    ImportCountry(l);
                }
            }
        }

        private void ImportCountry(string l)
        {
            var urlStrt = l.IndexOf("<a href");
            var urlEnd = l.IndexOf(" style=");
            var ctryStrt = l.IndexOf("em;");
            var ctryEnd = l.IndexOf("</a> (");
            var urlPart = l.Substring(urlStrt + 9, (urlEnd - urlStrt) - 10).Replace("&amp;", "&");
            var name = l.Substring(ctryStrt + 5, (ctryEnd - ctryStrt) - 5);
            var url = $"http://fmstream.org/{urlPart}";

            //ImportStationHtml html = new(url);
            Add(new Country { CountryName = name, MainUrl = url });
        }

        private string[] LoadFile(string fileToLoad)
        {
            return System.IO.File.ReadAllLines(fileToLoad);
        }

        /// <summary>
        /// read the webside and convert it in a line-seperated string array
        /// </summary>
        /// <param name="siteToLoad"></param>
        /// <returns>string[]</returns>
        private string[] LoadWebSite(string siteToLoad)
        {
            System.Net.WebClient wc = new();
            byte[] raw = wc.DownloadData(siteToLoad);

            return System.Text.Encoding.UTF8.GetString(raw).Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None); ;
        }

        private static void PrintDetails(string urlPart, string url)
        {
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            Console.WriteLine(urlPart);
            Console.WriteLine(url);
        }
    }


}
