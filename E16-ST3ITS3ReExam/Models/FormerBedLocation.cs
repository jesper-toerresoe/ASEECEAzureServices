using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E16_ST3ITS3ReExam.Models
{
    /// <summary>
    /// Beskrivelse af en sengs tidligere placering
    /// Sammelede beskrivelser udgør historikken over placeringer
    /// </summary>
    public class FormerBedLocation
    {
        /// <summary>
        /// Skal tilskrives værdien 0 ved oprettelsen af en historisk placering.
        /// Gives herefter automatisk en meningsfuld nøgleværdi af Bed Location Service.
        /// </summary>
        [Key]
        public long FormerBedLocationId { get; set; }
        /// <summary>
        /// Eks: "JRT" eller "AUH200255"
        /// </summary>
        [Required]
        public string ReportingPorterId { get; set; }
        /// <summary>
        /// Tekstbeskrivelse af tidligere sengeplacering
        /// Eks. "Bygning 400 3. Etage Stue 12"
        /// </summary>
        [Required]
        public string FormerLocation { get; set; }
        /// <summary>
        /// Dato og tidspunkt for tidligere placering
        /// Eks. "2017-02-13T15:30:14.50"
        /// </summary>
        [Required]
        public DateTime DateTimeStampFormerPos { get; set; }
        /// <summary>
        /// Mulig GPS-angivelse af sengens tidligere placering
        /// Optionel felt.
        /// </summary>
        public string AvailFormerLocGPS { get; set; }

    }
}