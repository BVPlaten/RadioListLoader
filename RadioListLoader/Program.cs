// See https://aka.ms/new-console-template for more information
using RadioDb;
using RadioDb.DataAccess;
using RadioDb.Models;
using System.Linq;
using System.Text;

RadioDb.RadioDb? dataBase = new();
RadioDb.CountryData? ctr = new CountryData(@"http://fmstream.org/country.htm");
Dictionary<string,List<string>> dataByCountry = new();

// prepare a list of strinbgs for every given country
foreach (var c in ctr)
{
    dataByCountry[c.CountryName] = new List<string>();
}

// read the data
Parallel.ForEach(ctr, c => 
{
    // get all countries in parralel 
    global::System.Console.WriteLine($"importing {c.CountryName} - - -");
    ImportStationHtml html = new(c.MainUrl);
    dataByCountry[c.CountryName].AddRange(html.data);
});

// write a file for every country
foreach (var c in ctr)
{
    File.WriteAllLines($"D:\\temp\\station_data_raw__{c.CountryName}.txt", dataByCountry[c.CountryName], Encoding.UTF8);   
}
return;

