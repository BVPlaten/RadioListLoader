using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioDb
{
    /* 
     * class to iterate to all html-files of a country and store the JSON
     * data into a list.
     * the class checks if there is some data to import. if no stations 
     * left the loop will end 
     * 
     * */
    /// <summary>
    /// import html data. every text from a page will be stored in a string.
    /// </summary>
    public class ImportStationHtml
    {
        private int i;
        private string ctryIdx;
        public List<string> data { get; set; }

        /// <summary>
        /// load all stations from a given country
        /// </summary>
        /// <param name="startUrl"></param>
        public ImportStationHtml(string startUrl)
        {
            // 1. get the website 
            i = 0;
            ctryIdx = "n=0";
            data = new();
            GetSite(startUrl);

        }

        /// <summary>
        /// load parts of the country and add raw data to a list (data)
        /// </summary>
        /// <param name="strtUrl"></param>
        private void GetSite( string strtUrl)
        {
            var siteToLoad = strtUrl.Replace("o=top", ctryIdx);
            //Console.WriteLine($"Loading Site {siteToLoad} !");
            System.Net.WebClient wc = new();
            byte[] raw = wc.DownloadData(siteToLoad);
            var htmlTxt = System.Text.Encoding.UTF8.GetString(raw);
            var laenge = htmlTxt.Length;
            int start = htmlTxt.IndexOf("var data=[[[") + "var data=".Length;
            int end = htmlTxt.IndexOf("]]];") + 4;

            if (start == 8)
                return;
            else
            {
                data.Add(htmlTxt.Substring(start, end - start));
                i += 100;
                var newStrt = strtUrl.Replace(ctryIdx, $"n={i}");
                ctryIdx = $"n={i}";
                GetSite(newStrt);
            }
        }
    }
}
