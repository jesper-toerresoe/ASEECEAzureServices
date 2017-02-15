namespace E16_ST3ITS3ExamOrdinary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        LTBloodGlucoseReport_LTBloodGlucoseReportId = c.Long(),
                    })
                .PrimaryKey(t => t.SelfHelpCourseID)
                .ForeignKey("dbo.LTBloodGlucoseReports", t => t.LTBloodGlucoseReport_LTBloodGlucoseReportId)
                .Index(t => t.LTBloodGlucoseReport_LTBloodGlucoseReportId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SelfHelpCourses", "LTBloodGlucoseReport_LTBloodGlucoseReportId", "dbo.LTBloodGlucoseReports");
            DropIndex("dbo.SelfHelpCourses", new[] { "LTBloodGlucoseReport_LTBloodGlucoseReportId" });
            DropTable("dbo.SelfHelpCourses");
            DropTable("dbo.LTBloodGlucoseReports");
        }
    }
}
