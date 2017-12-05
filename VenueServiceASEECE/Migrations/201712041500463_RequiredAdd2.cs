namespace VenueServiceASEECE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredAdd2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Monthday", c => c.String());
            AlterColumn("dbo.Events", "Month", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Year", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Time", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "VPlaceforEvent", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "VPlaceforEvent", c => c.String());
            AlterColumn("dbo.Events", "Time", c => c.String());
            AlterColumn("dbo.Events", "Year", c => c.String());
            AlterColumn("dbo.Events", "Month", c => c.String());
            AlterColumn("dbo.Events", "Monthday", c => c.String(nullable: false));
        }
    }
}
