﻿
namespace EverCareCommunity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum GenderType
{
    Male,
    Female,
    Other
}

public class ElderlyResident
{
    [Key]
    public int ResidentID { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
    [RegularExpression(@"^[A-Za-z\s'-]+$", ErrorMessage = "First name can only contain letters, spaces, hyphens, and apostrophes.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
    [RegularExpression(@"^[A-Za-z\s'-]+$", ErrorMessage = "Last name can only contain letters, spaces, hyphens, and apostrophes.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [StringLength(100, ErrorMessage = "Email must not exceed 100 characters.")]
    public string Email { get; set; }

    [Phone(ErrorMessage = "Invalid phone number format.")]
    [StringLength(15, MinimumLength = 7, ErrorMessage = "Phone number must be between 7 and 15 digits.")]
    [RegularExpression(@"^\+?[0-9\s-]+$", ErrorMessage = "Phone number can only contain digits, spaces, dashes, and an optional leading +.")]
    public string PhoneNumber { get; set; }

    public GenderType Gender { get; set; }


    [Required]
    [DataType(DataType.Date)]
    [CustomValidation(typeof(ElderlyResident), nameof(ValidateDateOfBirth))]
    public DateTime ? DateOfBirth { get; set; }

    public static ValidationResult ValidateDateOfBirth(DateTime dob, ValidationContext context)
    {
        int age = DateTime.Today.Year - dob.Year;
        if (dob > DateTime.Today.AddYears(-age)) age--; // Adjust if birthday hasn't occurred yet

        return age >= 40 ? ValidationResult.Success : new ValidationResult("Person must be at least 40 years old.");
    }




    [MaxLength(255)]
    public string Address { get; set; }

    public ICollection<MedicalCondition> MedicalConditions { get; set; } = new List<MedicalCondition>();
    public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    // Updated EmergencyContacts to use a proper entity
    public ICollection<EmergencyContact> EmergencyContacts { get; set; } = new List<EmergencyContact>();

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<CaregiverResidentAssignment> CaregiverAssignments { get; set; } = new List<CaregiverResidentAssignment>();
    public ICollection<Address> Addresses { get; set; }
}
