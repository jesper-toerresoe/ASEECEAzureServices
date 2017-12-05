namespace VenueServiceASEECE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredAdd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Weekday", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Monthday", c => c.String(nullable: false));
            AlterColumn("dbo.Venues", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Venues", "Street", c => c.String(nullable: false));
            AlterColumn("dbo.Venues", "Town", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Venues", "Town", c => c.String());
            AlterColumn("dbo.Venues", "Street", c => c.String());
            AlterColumn("dbo.Venues", "Name", c => c.String());
            AlterColumn("dbo.Events", "Monthday", c => c.String());
            AlterColumn("dbo.Events", "Weekday", c => c.String());
            AlterColumn("dbo.Events", "Title", c => c.String());
        }
    }
}
