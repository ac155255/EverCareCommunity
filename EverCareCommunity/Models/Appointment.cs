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

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime dateTime)
        {
            if (dateTime > DateTime.UtcNow) 
            {
                return ValidationResult.Success;
            }
            return new ValidationResult($"The appointment date must be in the future. Current UTC time: {DateTime.UtcNow}");
        }
        return new ValidationResult("Invalid date format.");
    }
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
    [FutureDate]
    public DateTime DateTime { get; set; }

    // Navigation Properties
    public Doctor Doctor { get; set; }
    public ElderlyResident ElderlyResident { get; set; }
}