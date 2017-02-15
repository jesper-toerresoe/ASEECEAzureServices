using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E15_ST3ProgrammeringReexam.Models
{
    public class E15_ST3ProgrammeringReexamContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public E15_ST3ProgrammeringReexamContext() : base("name=E15_ST3ProgrammeringReexamContext")
        {
        }

        public System.Data.Entity.DbSet<E15_ST3ProgrammeringReexam.Models.ReminderDentistExam> ReminderDentistExams { get; set; }
    }
}
