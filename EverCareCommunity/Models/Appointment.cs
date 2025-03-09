namespace EverCareCommunity.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



public enum AppointmentStatus
{
    Scheduled,
    Completed,
    Cancelled
}


public class Appointment
{
    [Key]
    public int AppointmentID { get; set; }

    [ForeignKey("ElderlyResident")]
    public int ResidentID { get; set; }

    [ForeignKey("Doctor")]
    public int DoctorID { get; set; }

    public AppointmentStatus Status { get; set; }


    [Required]
     [FutureDateValidation]
    public DateTime DateTime { get; set; }


    public class FutureDateValidation : ValidationAttribute
    {
        public FutureDateValidation() : base("The appointment date must be within the next year and in the future.") { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime currentDate = DateTime.Now;
            DateTime inputDate = (DateTime)value;

            if (inputDate <= currentDate)
            {
                return new ValidationResult("The appointment date must be a future date.");
            }

            if (inputDate > currentDate.AddYears(1))
            {
                return new ValidationResult("The appointment date cannot be more than one year in the future.");
            }

            return ValidationResult.Success;
        }
    }

    
   
    // Corrected Navigation Properties
    public Doctor Doctor { get; set; }
    public ElderlyResident ElderlyResident { get; set; }
}