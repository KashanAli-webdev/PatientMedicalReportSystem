using PatientRecordCURDWebApp.Utilities;
using System.ComponentModel.DataAnnotations;

namespace PatientRecordCURDWebApp.Models
{
    public class Patient
    {
        [Key, Display(Name = "Id")]
        public Guid PatientId { get; set; }


        [Required, Display(Name = "Name", Prompt = "Full Name"), StringLength(30), 
            RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Letters and spaces only")]
        public string? PatientName { get; set; }


        [Required, Display(Name = "Gender")]
        public Gender PatientGender { get; set; }


        [Required, Range(0, 130), Display(Name = "Age", Prompt = "0 to 130")]
        public byte PatientAge { get; set; }


        [Required, Phone, StringLength(14), Display(Name = "Contact", 
            Prompt = "11-13 digits, + at start, - after region code allow"),
            RegularExpression(@"^\+?\d{4,6}-?\d{7}$", ErrorMessage = "Enter Digits, -, + only.")]
        public string? PatientContact { get; set; }


        [Required] // Navigation property required for realation in between.
        public MedicalRecord? MedicalRecord { get; set; }
    }
}
