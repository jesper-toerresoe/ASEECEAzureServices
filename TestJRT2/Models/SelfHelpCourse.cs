using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestJRT2.Models
{
    public class SelfHelpCourse
    {
        public long SelfHelpCourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseType { get; set; }
        public bool Accepted { get; set; }
        public bool Ongoing { get; set; }
        //[ForeignKey("BelongsToRep")]
        //public long BelongsToRepID { get; set; }


        //public LTBloodGlucoseReport BelongsToRep { get; set; }
      
        //public DateTime StartTime { get; set; }
        //public DateTime EndTime { get; set; }

    }
}