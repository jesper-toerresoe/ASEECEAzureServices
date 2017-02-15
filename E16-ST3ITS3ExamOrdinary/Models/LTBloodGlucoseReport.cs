using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E16_ST3ITS3ExamOrdinary.Models
{
    public class LTBloodGlucoseReport
    {
        /// <summary>
        /// Udfyldes automatisk af LTBGM Service
        /// </summary>
        public long LTBloodGlucoseReportId { get; set; }
        /// <summary>
        /// Navn på indrapporterende klinik
        /// Navnet MÅ IKKE indeholde blanke tegn.
        /// Korrekt: CenterVest. Forkert: Center Vest.  
        /// </summary>
        [Required]
        public string ReportingClinicName { get; set; }
        /// <summary>
        /// Klinikkens egen endtydige identifikation af blodprøven.
        /// </summary>
        [Required]
        public long SampleIdFromClinic { get; set; }
        /// <summary>
        /// Navn på borger
        /// </summary>
        [Required]
        public string CitizenName { get; set; }
        /// <summary>
        /// Langtidsblodsukker i mmol/l
        /// </summary>
        [Required]
        public float MmolperLitre { get; set; }
        /// <summary>
        /// Dato og tidspunkt for udtagning af blodprøve
        /// </summary>
        [Required]
        public DateTime SampleTime { get; set; }
        /// <summary>
        /// Indikator for om Selvhjælpskurser er tilbudt til borger
        /// </summary>
        [Required]
        public bool SelfHelpCoursesProvided { get; set; }
        /// <summary>
        /// Listen over tilbudte Selvhjælpskurser
        /// </summary>
        public virtual ICollection<SelfHelpCourse> SelfHelpCourses { get; set; }

    }
}