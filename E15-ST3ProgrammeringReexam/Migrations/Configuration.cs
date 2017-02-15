namespace E15_ST3ProgrammeringReexam.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using E15_ST3ProgrammeringReexam.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<E15_ST3ProgrammeringReexam.Models.E15_ST3ProgrammeringReexamContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(E15_ST3ProgrammeringReexam.Models.E15_ST3ProgrammeringReexamContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.ReminderDentistExams.AddOrUpdate(x => x.Id,
               new ReminderDentistExam()
               {
                   Id = 1,
                   CustomerName = "Gudrun",
                   CustummerFamliyName = "Sørensen",
                   Adress = "Villa 58 ST.V",
                   PostalCode = "8000",
                   Town = "Aarhus",
                   ExaminatonTimeOf = "14:30",
                   ExaminatonDateOf = "12-12-2015",
                   DentalClinic = "Klinikken på Clementsbro"                   
               }
                );

            //    public class ReminderDentistExam
            //{
            //    public int Id { get; set; }
            //    [Required]
            //    public string CustomerName { get; set; }
            //    [Required]
            //    public string CustummerFamliyName { get; set; }
            //    [Required]
            //    public string Adress { get; set; }
            //    [Required]
            //    public string Town { get; set; }
            //    [Required]
            //    public string PostalCode { get; set; }
            //    [Required]
            //    public string ExaminatonTimeOf { get; set; }
            //    [Required]
            //    public string ExaminatonDateOf { get; set; }
            //    [Required]
            //    public string DentalClinic { get; set; }

            //}

        }
    }
}
