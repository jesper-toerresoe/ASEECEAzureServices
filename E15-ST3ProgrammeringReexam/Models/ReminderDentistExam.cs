using System.ComponentModel.DataAnnotations;


namespace E15_ST3ProgrammeringReexam.Models
{
    public class ReminderDentistExam
    {
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustummerFamliyName { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Town { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string ExaminatonTimeOf { get; set; }
        [Required]
        public string ExaminatonDateOf { get; set; }
        [Required]
        public string DentalClinic { get; set; }

    }
}
