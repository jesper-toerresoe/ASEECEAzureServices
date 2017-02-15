using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace F16_ST3P3Opgave.Models
{
    public class F16_ST3P3OpgaveContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public F16_ST3P3OpgaveContext() : base("name=F16_ST3P3OpgaveContext")
        {
        }

        public System.Data.Entity.DbSet<F16_ST3P3Opgave.Models.Venue> Venues { get; set; }

        public System.Data.Entity.DbSet<F16_ST3P3Opgave.Models.Event> Events { get; set; }
    }
}
