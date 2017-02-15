namespace E16_ST3ITS3ReExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinorChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BedLocationJournals", "CurrentLocation", c => c.String(nullable: false));
            AddColumn("dbo.BedLocationJournals", "AvailableCurLocGPS", c => c.String());
            AddColumn("dbo.FormerBedLocations", "AvailFormerLocGPS", c => c.String());
            DropColumn("dbo.BedLocationJournals", "CurrentLocat");
            DropColumn("dbo.BedLocationJournals", "PossibleCurLocGPS");
            DropColumn("dbo.FormerBedLocations", "PossibleFormerLocGPS");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FormerBedLocations", "PossibleFormerLocGPS", c => c.String());
            AddColumn("dbo.BedLocationJournals", "PossibleCurLocGPS", c => c.String());
            AddColumn("dbo.BedLocationJournals", "CurrentLocat", c => c.String(nullable: false));
            DropColumn("dbo.FormerBedLocations", "AvailFormerLocGPS");
            DropColumn("dbo.BedLocationJournals", "AvailableCurLocGPS");
            DropColumn("dbo.BedLocationJournals", "CurrentLocation");
        }
    }
}
