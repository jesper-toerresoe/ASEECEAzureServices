namespace VenueServiceASEECE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Weekday = c.String(),
                        Monthday = c.String(),
                        Month = c.String(),
                        Year = c.String(),
                        Time = c.String(),
                        VPlaceforEvent = c.String(),
                        Venue_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Venues", t => t.Venue_Id)
                .Index(t => t.Venue_Id);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Street = c.String(),
                        Town = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Venue_Id", "dbo.Venues");
            DropIndex("dbo.Events", new[] { "Venue_Id" });
            DropTable("dbo.Venues");
            DropTable("dbo.Events");
        }
    }
}
