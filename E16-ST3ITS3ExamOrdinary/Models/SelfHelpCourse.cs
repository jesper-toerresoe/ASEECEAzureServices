using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E16_ST3ITS3ExamOrdinary.Models
{
    public class SelfHelpCourse
    {
        /// <summary>
        /// Udfyldes automatisk af LTBGM Service
        /// </summary>
        public long SelfHelpCourseID { get; set; }
        /// <summary>
        /// Kursets officielle navn (ex Perleplader udvidet niveau)
        /// </summary>
        [Required]
        public string CourseName { get; set; }
        /// <summary>
        /// Typen på kurset (ex. Terapi og hobby)
        /// </summary>
        [Required]
        public string CourseType { get; set; }
        /// <summary>
        /// Indikator om hvorvidt borger vil deltage eller ej.
        /// </summary>
        [Required]
        public bool Accepted { get; set; }
        /// <summary>
        /// Indikator for om borger følger kurset.
        /// </summary>
        [Required]
        public bool Ongoing { get; set; }
        //[ForeignKey("BelongsToRep")]
        //public long BelongsToRepID { get; set; }


        //public LTBloodGlucoseReport BelongsToRep { get; set; }
      
        //public DateTime StartTime { get; set; }
        //public DateTime EndTime { get; set; }

    }
}