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

// this AgeRangeAttribute vaildation only accepts residents from 30 to 120 years old
public class AgeRangeAttribute : ValidationAttribute
{
    private readonly int _minAge;
    private readonly int _maxAge;

    public AgeRangeAttribute(int minAge, int maxAge)
    {
        _minAge = minAge;
        _maxAge = maxAge;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime date)
        {
            var today = DateTime.Today;
            int age = today.Year - date.Year;
            if (date.Date > today.AddYears(-age)) age--; 

            if (age < _minAge || age > _maxAge)
            {
                return new ValidationResult($"Age must be between {_minAge} and {_maxAge} years.");
            }
        }
        return ValidationResult.Success;
    }
}

public class ElderlyResident
{
    [Key]
    public int ResidentID { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    [StringLength(25, MinimumLength = 1, ErrorMessage = "First name must be between 1 and 25 characters.")]
    [RegularExpression(@"^[A-Za-z\s'-]+$", ErrorMessage = "First name can only contain letters, spaces, hyphens, and apostrophes.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(25, MinimumLength = 1, ErrorMessage = "Last name must be between 1 and 25 characters.")]
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
    [AgeRange(30, 150, ErrorMessage = "Age must be between 30 and 120 years.")]
    public DateTime ? DateOfBirth { get; set; }


    [MaxLength(255)]
    public string Address { get; set; }

    public ICollection<MedicalCondition> MedicalConditions { get; set; } = new List<MedicalCondition>();
    public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

   
    public ICollection<EmergencyContact> EmergencyContacts { get; set; } = new List<EmergencyContact>();

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<CaregiverResidentAssignment> CaregiverAssignments { get; set; } = new List<CaregiverResidentAssignment>();
    public ICollection<Address> Addresses { get; set; }
}
