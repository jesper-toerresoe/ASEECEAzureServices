using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E16_ST3ITS3ExamOrdinary.Models
{
    public class LTBGMContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    /// <summary>
    /// 
    /// </summary>
        public LTBGMContext() : base("name=LTBGMContext")
        {
            /*
         * http://stackoverflow.com/questions/3372895/datacontractserializer-error-using-entity-framework-4-0-with-wcf-4-0
         * */
            Configuration.ProxyCreationEnabled = false;

            //this.Database.Log = s => System.Console.WriteLine(s);
            //this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<LTBloodGlucoseReport> LTBloodGlucoseReports { get; set; }
        public DbSet<SelfHelpCourse> SelfHelpCourses { get; set; }
    }
}
