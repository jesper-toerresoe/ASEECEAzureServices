using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenueServiceASEECE.Models
{
    /// <summary>
    /// Et "Event" er en begivenhed/et arrangement, om sker på et givent spillested/Venue
    /// Første gang et Event indrapporteres skal POST request benyttes og efterfølgende
    /// opdateringer sker med PUT request.
    /// Men typisk oprettes Events via tilføjelse til et givent spillested/Venue. 
    /// Enten når et Venue oprettes (POST) eller når er Venue
    /// ændres (PUT)
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Id må ikke ændres et skrives af klienten men tildeles alene af VenueServiceASEECE
        /// Skal være 0 (nul) for et nyoprettet Event både når Event oprettes separat og 
        /// i forbindelse med oprettelse eller ændring af et Venue
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Titel på det givne Arrangement/Event
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// Uge for arrangememt 
        /// </summary>
 
        [Required]
        public string Weekday { get; set; }
        /// <summary>
        /// Månedsdag for arrangement (Format frit)
        /// </summary>

        [Required]
        public string Monthday { get; set; }
        /// <summary>
        /// Måned for arrangement (Format frit)
        /// </summary>
        [Required]
        public string Month { get; set; }
        /// <summary>
        /// År for arrangment (Format frit)
        /// </summary>
        [Required]
        public string Year { get; set; }
        /// <summary>
        /// Klokkeslæt for arrangement (Format frit)
        /// </summary>
        [Required]
        public string Time { get; set; }
        /// <summary>
        /// Navn for Venue/Spillested hvor arrangement afholdes (Format frit)
        /// </summary>
        [Required]
        public string VPlaceforEvent { get; set; }
       
    }
}
