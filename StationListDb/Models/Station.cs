using StationListDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioDb.Models
{
    /*
     * the station class represents a radio-station with it 
     * associated streams 
     * 
     * */
    public class Station
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<StreamUrl> Streams { get; set; }
    }
}
