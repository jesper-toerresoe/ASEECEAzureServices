namespace TestJRT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseFKRemove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SelfHelpCourses", "BelongsToRepID", "dbo.LTBloodGlucoseReports");
            DropIndex("dbo.SelfHelpCourses", new[] { "BelongsToRepID" });
            RenameColumn(table: "dbo.SelfHelpCourses", name: "BelongsToRepID", newName: "LTBloodGlucoseReport_LTBloodGlucoseReportId");
            AlterColumn("dbo.SelfHelpCourses", "LTBloodGlucoseReport_LTBloodGlucoseReportId", c => c.Long());
            CreateIndex("dbo.SelfHelpCourses", "LTBloodGlucoseReport_LTBloodGlucoseReportId");
            AddForeignKey("dbo.SelfHelpCourses", "LTBloodGlucoseReport_LTBloodGlucoseReportId", "dbo.LTBloodGlucoseReports", "LTBloodGlucoseReportId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SelfHelpCourses", "LTBloodGlucoseReport_LTBloodGlucoseReportId", "dbo.LTBloodGlucoseReports");
            DropIndex("dbo.SelfHelpCourses", new[] { "LTBloodGlucoseReport_LTBloodGlucoseReportId" });
            AlterColumn("dbo.SelfHelpCourses", "LTBloodGlucoseReport_LTBloodGlucoseReportId", c => c.Long(nullable: false));
            RenameColumn(table: "dbo.SelfHelpCourses", name: "LTBloodGlucoseReport_LTBloodGlucoseReportId", newName: "BelongsToRepID");
            CreateIndex("dbo.SelfHelpCourses", "BelongsToRepID");
            AddForeignKey("dbo.SelfHelpCourses", "BelongsToRepID", "dbo.LTBloodGlucoseReports", "LTBloodGlucoseReportId", cascadeDelete: true);
        }
    }
}
