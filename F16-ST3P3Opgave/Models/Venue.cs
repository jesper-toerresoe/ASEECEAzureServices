using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F16_ST3P3Opgave.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public List<Event> CommingEvents { get; set; }

    }
}