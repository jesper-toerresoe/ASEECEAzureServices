namespace E15_ST3ProgrammeringReexam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReminderDentistExams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false),
                        CustummerFamliyName = c.String(nullable: false),
                        Adress = c.String(nullable: false),
                        Town = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        ExaminatonTimeOf = c.String(nullable: false),
                        ExaminatonDateOf = c.String(nullable: false),
                        DentalClinic = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReminderDentistExams");
        }
    }
}
