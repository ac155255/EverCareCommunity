namespace EverCareCommunity.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Caregiver
{
    [Key]
    public int CaregiverID { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
    [RegularExpression(@"^[A-Za-z\s'-]+$", ErrorMessage = "First name can only contain letters, spaces, hyphens, and apostrophes.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
    [RegularExpression(@"^[A-Za-z\s'-]+$", ErrorMessage = "Last name can only contain letters, spaces, hyphens, and apostrophes.")]
    public string LastName { get; set; }

    public Qualification QualificationType { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [StringLength(100, ErrorMessage = "Email must not exceed 100 characters.")]
    public string Email { get; set; }

    [Phone(ErrorMessage = "Invalid phone number format.")]
    [StringLength(15, MinimumLength = 7, ErrorMessage = "Phone number must be between 7 and 15 digits.")]
    [RegularExpression(@"^\+?[0-9\s-]+$", ErrorMessage = "Phone number can only contain digits, spaces, dashes, and an optional leading +.")]
    public string Phone { get; set; }

    
    public enum Qualification
    {
        FirstAidAndCPR,
        CaregiverCertification,
        HomeHealthAideCertification,
        FoodHandlingAndNutrition,
        AlzheimersAndDementiaCare
    }

    
    public int Experience { get; set; }

    public bool Availability { get; set; }

    
}
