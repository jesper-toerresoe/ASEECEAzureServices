namespace E15_ST3ProgrammeringExamOrdinary.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<E15_ST3ProgrammeringExamOrdinary.Models.E15_ST3ProgrammeringExamOrdinaryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(E15_ST3ProgrammeringExamOrdinary.Models.E15_ST3ProgrammeringExamOrdinaryContext context)
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
            context.ConveningforScreenings.AddOrUpdate(x => x.Id,
               new ConveningforScreening()
               {
                   Id = 1,
                   FirstName = "Gudrun",
                   FamliyName = "Sørensen",
                   StreetName = "Villa 58 ST.V",
                   ZipCode = "8000",
                   City = "Aarhus",
                   TimeforScreening = "14:30",
                   DateforScreening = "12-12-2015",
                   ClinicName = "AUH Afd X Palle Juul Jensen Bouldevard"

                   
               },
               new ConveningforScreening()
               {
                   Id = 2,
                   
                   FirstName = "Gudrun",
                   FamliyName = "Sørensen",
                   StreetName = "Villa 58 ST.V",
                   ZipCode = "8000",
                   City = "Aarhus",
                   TimeforScreening = "14:30",
                   DateforScreening = "12-12-2015",
                   ClinicName = "AUH Afd X Palle Juul Jensen Bouldevard"
               },
               new ConveningforScreening()
               {
                   Id = 3,
                   FirstName = "Mette",
                   FamliyName = "Hansen",
                   StreetName = "Vibrig 67",
                   ZipCode = "9000",
                   City = "Aalborg",
                   TimeforScreening = "15:30",
                   DateforScreening = "12-01-2016",
                   ClinicName = "AUH Afd X Palle Juul Jensen Bouldevard"
               },
               new ConveningforScreening()
               {
                   Id = 4,
                   FirstName = "Jenny",
                   FamliyName = "Fandsen",
                   StreetName = "Engbakkevej 126",
                   ZipCode = "6700",
                   City = "Esbjerg",
                   TimeforScreening = "10:15",
                   DateforScreening = "21-01-2016",
                   ClinicName = "AUH Afd X Palle Juul Jensen Bouldevard"
               },
               new ConveningforScreening()
               {
                   Id = 5,
                   FirstName = "Tove",
                   FamliyName = "Tovesen",
                   StreetName = "Kattesundet 17",
                   ZipCode = "8770",
                   City = "Hadsten",
                   TimeforScreening = "08:45",
                   DateforScreening = "11-01-2016",
                   ClinicName = "AUH Afd X Palle Juul Jensen Bouldevard"
               }
               );
        }
    }
}
