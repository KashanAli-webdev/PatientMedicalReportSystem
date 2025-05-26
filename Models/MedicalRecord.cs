using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientRecordCURDWebApp.Models
{
    public class MedicalRecord
    {
        [Key, ForeignKey("Patient")] // Link Patient Id as (PK, FK) define as one to one relation.
        public Guid PatientId { get; set; }


        [Required, StringLength(3), Display(Name = "Blood Group", Prompt = "A+, B-, O+, AB+, etc."),
            RegularExpression(@"^(?:A|B|AB|O)[+-]|N/D$", ErrorMessage = "Invalid blood group.")]
        public string BloodGroup { get; set; } = "N/D";


        [Required, StringLength(4), Display(Name = "Hepatitis Type", Prompt = "A, B, C or None."), 
            RegularExpression(@"^(?:A|B|C|N/D|None)$", ErrorMessage = "Invalid hepatitis type input.")]
        public string HepatitisType { get; set; } = "N/D";


        [Required, StringLength(11), Display(Name = "Cholesterol Level", 
            Prompt = "Normal, High, Borderline or as 210 mg/dL"), 
            RegularExpression(@"^(Normal|High|Borderline|\d{2,3}\s?mg/dL|N/D)$",
            ErrorMessage = "Invalid cholesterol level.")]
        public string CholesterolLevel { get; set; } = "N/D";


        [Required, StringLength(11), Display(Name = "Blood Pressure", 
            Prompt = "Normal, High, Borderline or as 120/80"),
            RegularExpression(@"^(\d{2,3}/\d{2,3}|N/D|Normal|High|Borderline)$", 
            ErrorMessage = "Invalid blood pressure format.")]
        public string BloodPressure { get; set; } = "N/D";


        [Required, StringLength(21), Display(Name = "Sugar Level", 
            Prompt = "Fasting/Random: Normal, High or as 110 mg/dL"),
            RegularExpression(@"^(Fasting|Random):\s?(Normal|High|Borderline|\d{2,3}\s?mg/dL)$|^N/D$", 
            ErrorMessage = "Invalid sugar level format.")]
        public string SugarLevel { get; set; } = "N/D";


        [Required, Display(Name = "Allergies", Prompt = "Dust, Flowers, etc"), 
            RegularExpression(@"^([\w\s,.-]{2,200}|N/D)$", 
            ErrorMessage = "Invalid medical history format.")]
        public string Allergies { get; set; } = "N/D";  // e.g., "Penicillin, Pollen"


        [Required, Display(Name = "Chronic Diseases", Prompt = "Diabetes, Hypertension, etc"), 
            RegularExpression(@"^([\w\s,.-]{2,200}|N/D)$", 
            ErrorMessage = "Invalid medical history format.")]
        public string ChronicDiseases { get; set; } = "N/D";


        [Required, Display(Name = "Medical History", Prompt = "None, Operated, etc"),
            RegularExpression(@"^([\w\s,.-]{2,200}|N/D)$", 
            ErrorMessage = "Invalid medical history format.")]
        public string MedicalHistory { get; set; } = "N/D"; // e.g., "Metformin, Lisinopril"
    }

}
