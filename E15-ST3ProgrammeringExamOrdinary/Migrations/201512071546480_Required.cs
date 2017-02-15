namespace E15_ST3ProgrammeringExamOrdinary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ConveningforScreenings", "FamliyName", c => c.String(nullable: false));
            AlterColumn("dbo.ConveningforScreenings", "StreetName", c => c.String(nullable: false));
            AlterColumn("dbo.ConveningforScreenings", "City", c => c.String(nullable: false));
            AlterColumn("dbo.ConveningforScreenings", "ZipCode", c => c.String(nullable: false));
            AlterColumn("dbo.ConveningforScreenings", "TimeforScreening", c => c.String(nullable: false));
            AlterColumn("dbo.ConveningforScreenings", "DateforScreening", c => c.String(nullable: false));
            AlterColumn("dbo.ConveningforScreenings", "ClinicName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ConveningforScreenings", "ClinicName", c => c.String());
            AlterColumn("dbo.ConveningforScreenings", "DateforScreening", c => c.String());
            AlterColumn("dbo.ConveningforScreenings", "TimeforScreening", c => c.String());
            AlterColumn("dbo.ConveningforScreenings", "ZipCode", c => c.String());
            AlterColumn("dbo.ConveningforScreenings", "City", c => c.String());
            AlterColumn("dbo.ConveningforScreenings", "StreetName", c => c.String());
            AlterColumn("dbo.ConveningforScreenings", "FamliyName", c => c.String());
        }
    }
}
