using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E16_ST3ITS3ReExam.Models
{
    /// <summary>
    /// Journalen for en hospitalssengs gældende placering samt historikken.
    /// Skal opdaters i takt med en sengs ændringer i placeringen.
    /// Første gang en seng indrapporteres skal POST request benyttes og efterfølgende
    /// opdateringer sker med PUT request
    /// </summary>
    public class BedLocationJournal
    {
        /// <summary>
        /// Udfyldes automatisk af "Bed Location Service".
        /// Unikt nummer, som senere skal bruges ved ændring af en journal (PUT request!).
        /// </summary>
        [Key]
        public long BedLocationJournalId { get; set; }
        /// <summary>
        /// Eks: "Medicinsk Endokrinologisk Afdeling"
        /// </summary>
        [Required]
        public string ReportingWardName { get; set; }
        /// <summary>
        /// Eks: "Afd MEA" eller "AUHMEA-3434"
        /// </summary>
        [Required]
        public string ReportingWardId { get; set; }
        /// <summary>
        /// Eks: "JRT" eller "AUH200255"
        /// </summary>
        [Required]
        public string ReportingHospitalPorterId { get; set; }
        /// <summary>
        /// Tekstbeskrivelse af sengens placering
        /// Eks. "Bygning 400 2. Etage Stue 3"
        /// </summary>
        [Required]
        public string CurrentLocation { get; set; }
        /// <summary>
        /// Dato og tidspunkt for placering
        /// Eks. "2017-02-15T10:42:04.91"
        /// </summary>
        [Required]
        public DateTime DateTimeStampCurrPosition { get; set; }
        /// <summary>
        /// Mulig GPS-angivelse af sengens placering
        /// Optionel felt.
        /// </summary>
        public string AvailableCurLocGPS { get; set; }
        /// <summary>
        /// Liste/Historikken over tidligere placeringer for sengen
        /// Skal opateres i takt med at en ny placering gives.
        /// </summary>
        public virtual ICollection<FormerBedLocation> FormerBedLocations { get; set; }

    }
}