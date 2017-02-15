using System.ComponentModel.DataAnnotations;


namespace E15_ST3ProgrammeringExamOrdinary.Models
{
    public class ConveningforScreening
    {  
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string FamliyName { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string TimeforScreening { get; set; }
        [Required]
        public string DateforScreening { get; set; }
        [Required]
        public string ClinicName { get; set; }
        
    }
}
