using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenueServiceASEECE.Models
{
    /// <summary>
    /// Et spillested eller Venue et det sted, hvor et arrangemente/Event afholdes. Der er der
    /// er således tulknyttet en række Event  til spillestedet.
    /// Første gang et Venue oprettes skal POST request benyttes og efterfølgende
    /// opdateringer sker med PUT request.
    /// Typisk oprettes Events via tilføjelse til et givent spillested/Venue. 
    /// Enten når et Venue oprettes (POST) eller når er Venue
    /// ændres (PUT)
    /// </summary>
    public class Venue
    {
        /// <summary>
        /// Id må ikke ændres eller tilskrives en værdie af klienten, men tildeles alene af VenueServiceASEECE
        /// Skal være 0 (nul) ved POST for at nyoprette et Venue, og ellers ved PUT bruges det Id som
        /// Venue er hentet med 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Spille stedets navn (Format frit)
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Adresse for spillested (Format frit)
        /// </summary>
        [Required]
        public string Street { get; set; }
        /// <summary>
        /// Bynavn for spillested (Format frit)
        /// </summary>
        [Required]
        public string Town { get; set; }
        /// <summary>
        /// Landenavn som kan tilføjes 
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Listen af kommende Events på dette spillested
        /// Ved at tilføje et Event til listen med Event.ID = 0 vil eventet blive
        /// oprettet automatisk. Øvrige eksisterende Events kan rettes forudsat Event.Id
        /// ikke ændres
        /// </summary>
        public List<Event> CommingEvents { get; set; }

    }
}
