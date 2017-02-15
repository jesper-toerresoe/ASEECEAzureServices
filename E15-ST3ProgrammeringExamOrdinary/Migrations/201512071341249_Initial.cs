namespace E15_ST3ProgrammeringExamOrdinary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConveningforScreenings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        FamliyName = c.String(),
                        StreetName = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        TimeforScreening = c.String(),
                        DateforScreening = c.String(),
                        ClinicName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ConveningforScreenings");
        }
    }
}
