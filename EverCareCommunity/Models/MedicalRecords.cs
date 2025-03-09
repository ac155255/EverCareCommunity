namespace EverCareCommunity.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MedicalRecord
{
    [Key]
    public int RecordID { get; set; }

    [ForeignKey("ElderlyResident")]
    public int ResidentID { get; set; }

    [ForeignKey("Doctor")]
    public int DoctorID { get; set; }

    [Required(ErrorMessage = "Diagnosis is required.")]
    [StringLength(255, ErrorMessage = "Diagnosis must not exceed 255 characters.")]
    public string Diagnosis { get; set; }

    [MaxLength(500, ErrorMessage = "Prescription must not exceed 500 characters.")]
    public string Prescription { get; set; }

    [Required(ErrorMessage = "Date reported is required.")]
    [DataType(DataType.Date)]
    [CustomValidation(typeof(MedicalRecord), nameof(ValidateDateReported))]
    public DateTime DateReported { get; set; }

    public static ValidationResult ValidateDateReported(DateTime date, ValidationContext context)
    {
        DateTime today = DateTime.Today;

        if (date > today)
        {
            return new ValidationResult("Date reported cannot be in the future.");
        }
        return ValidationResult.Success;
    }

    public ElderlyResident ElderlyResident { get; set; }
    public Doctor Doctor { get; set; }
}
