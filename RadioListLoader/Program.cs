// See https://aka.ms/new-console-template for more information
using RadioDb;
using RadioDb.DataAccess;
using RadioDb.Models;
using System.Linq;

//CountryUrls? ctr = new CountryUrls(@"D:\temp\landesliste.html");

RadioDb.RadioDb? dataBase = new();
RadioDb.CountryData? ctr = new CountryData(@"http://fmstream.org/country.htm");

// import the json data of the stations 
List<string> rawJsn = new();
foreach (var i in ctr)
{
    ImportStationHtml html = new(i.MainUrl);
    Console.WriteLine( html.data.ToString() );
}
Console.WriteLine($"Anzahl geladene Websides = {rawJsn.Count} !!");

// update data-base - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
foreach (var ctry in ctr)
{
    dataBase.AddCountry(ctry);  
}
dataBase.db.SaveChanges();



//foreach (var cys in dataBase.db.CountryStations)
//{
//    var cd = new StationData(cys.MainUrl);
//}
return;

