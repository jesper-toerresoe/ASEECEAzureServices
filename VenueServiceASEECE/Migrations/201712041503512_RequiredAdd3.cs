namespace VenueServiceASEECE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredAdd3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Monthday", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Monthday", c => c.String());
        }
    }
}
