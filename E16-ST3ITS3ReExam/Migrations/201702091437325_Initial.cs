namespace E16_ST3ITS3ReExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BedLocationJournals",
                c => new
                    {
                        BedLocationJournalId = c.Long(nullable: false, identity: true),
                        ReportingWardName = c.String(nullable: false),
                        ReportingWardId = c.String(nullable: false),
                        ReportingHospitalPorterId = c.String(nullable: false),
                        CurrentLocat = c.String(nullable: false),
                        DateTimeStampCurrPosition = c.DateTime(nullable: false),
                        PossibleCurLocGPS = c.String(),
                    })
                .PrimaryKey(t => t.BedLocationJournalId);
            
            CreateTable(
                "dbo.FormerBedLocations",
                c => new
                    {
                        FormerBedLocationId = c.Long(nullable: false, identity: true),
                        ReportingPorterId = c.String(nullable: false),
                        FormerLocation = c.String(nullable: false),
                        DateTimeStampFormerPos = c.DateTime(nullable: false),
                        PossibleFormerLocGPS = c.String(),
                        BedLocationJournal_BedLocationJournalId = c.Long(),
                    })
                .PrimaryKey(t => t.FormerBedLocationId)
                .ForeignKey("dbo.BedLocationJournals", t => t.BedLocationJournal_BedLocationJournalId)
                .Index(t => t.BedLocationJournal_BedLocationJournalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FormerBedLocations", "BedLocationJournal_BedLocationJournalId", "dbo.BedLocationJournals");
            DropIndex("dbo.FormerBedLocations", new[] { "BedLocationJournal_BedLocationJournalId" });
            DropTable("dbo.FormerBedLocations");
            DropTable("dbo.BedLocationJournals");
        }
    }
}
