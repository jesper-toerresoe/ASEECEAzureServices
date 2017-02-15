namespace TestJRT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseFK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LTBloodGlucoseReports",
                c => new
                    {
                        LTBloodGlucoseReportId = c.Long(nullable: false, identity: true),
                        ReportingClinicName = c.String(nullable: false),
                        SampleIdFromClinic = c.Long(nullable: false),
                        CitizenName = c.String(nullable: false),
                        MmolperLitre = c.Single(nullable: false),
                        SampleTime = c.DateTime(nullable: false),
                        SelfHelpCoursesProvided = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LTBloodGlucoseReportId);
            
            CreateTable(
                "dbo.SelfHelpCourses",
                c => new
                    {
                        SelfHelpCourseID = c.Long(nullable: false, identity: true),
                        CourseName = c.String(),
                        CourseType = c.String(),
                        Accepted = c.Boolean(nullable: false),
                        Ongoing = c.Boolean(nullable: false),
                        BelongsToRepID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.SelfHelpCourseID)
                .ForeignKey("dbo.LTBloodGlucoseReports", t => t.BelongsToRepID, cascadeDelete: true)
                .Index(t => t.BelongsToRepID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SelfHelpCourses", "BelongsToRepID", "dbo.LTBloodGlucoseReports");
            DropIndex("dbo.SelfHelpCourses", new[] { "BelongsToRepID" });
            DropTable("dbo.SelfHelpCourses");
            DropTable("dbo.LTBloodGlucoseReports");
        }
    }
}
