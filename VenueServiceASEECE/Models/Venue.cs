using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenueServiceASEECE.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string Country { get; set; }
        public List<Event> CommingEvents { get; set; }

    }
}
