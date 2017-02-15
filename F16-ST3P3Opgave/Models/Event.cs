using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F16_ST3P3Opgave.Models
{
    public class Event
    {
        public int Id { get; set; }       
        public string Weekday { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Time { get; set; }
        public int VenueId { get; set; }
    }
}