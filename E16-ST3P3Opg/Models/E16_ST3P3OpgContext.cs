using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E16_ST3P3Opg.Models
{
    public class E16_ST3P3OpgContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public E16_ST3P3OpgContext() : base("name=E16_ST3P3OpgContext")
        {
        }

        public System.Data.Entity.DbSet<E16_ST3P3Opg.Models.Venue> Venues { get; set; }

        public System.Data.Entity.DbSet<E16_ST3P3Opg.Models.Event> Events { get; set; }
    }
}
