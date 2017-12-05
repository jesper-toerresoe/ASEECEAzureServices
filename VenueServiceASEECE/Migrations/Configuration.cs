namespace VenueServiceASEECE.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VenueServiceASEECE.Models.VenueServiceASEECEContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "VenueServiceASEECE.Models.VenueServiceASEECEContext";
        }

        protected override void Seed(VenueServiceASEECE.Models.VenueServiceASEECEContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
