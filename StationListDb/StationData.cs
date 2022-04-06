using RadioDb;
using RadioDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioDb
{
    /* # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #
     * 
     * the class stores the radio lists fom fmstream.org in a sqlite database
     * 
     * # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # # #
     * 
     * */
    public class StationData : List<Station>
    {
        string? url = null;

        public StationData(string mainUrl)
        {
            url = mainUrl;

            //foreach (Country? c in cd)
            //{
            //    string[] data = LoadWebSite(c.MainUrl);
            //    GetStations(data);
            //}
            return;
        }



        private string[] LoadWebSite(string siteToLoad)
        {
            System.Net.WebClient wc = new();
            byte[] raw = wc.DownloadData(siteToLoad);

            return System.Text.Encoding.UTF8.GetString(raw).Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None); ;
        }

        private void GetStations(string[] data)
        {
            return;
        }
    }
}
