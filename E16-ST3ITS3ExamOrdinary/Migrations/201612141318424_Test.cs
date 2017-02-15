namespace E16_ST3ITS3ExamOrdinary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SelfHelpCourses", "CourseName", c => c.String(nullable: false));
            AlterColumn("dbo.SelfHelpCourses", "CourseType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SelfHelpCourses", "CourseType", c => c.String());
            AlterColumn("dbo.SelfHelpCourses", "CourseName", c => c.String());
        }
    }
}
