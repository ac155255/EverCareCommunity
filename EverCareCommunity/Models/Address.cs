namespace EverCareCommunity.Models;
using System.ComponentModel.DataAnnotations;

public class Address
{
    [Key]
    public int AddressID { get; set; }

    [Required(ErrorMessage = "Street address is required.")]
    [StringLength(100, ErrorMessage = "Street address must not exceed 100 characters.")]
    public string Street { get; set; }

    [Required(ErrorMessage = "City is required.")]
    [StringLength(50, ErrorMessage = "City must not exceed 50 characters.")]
    [RegularExpression(@"^[A-Za-z\s'-]+$", ErrorMessage = "City can only contain letters, spaces, hyphens, and apostrophes.")]
    public string City { get; set; }

    [Required(ErrorMessage = "Zip code is required.")]
    [StringLength(10, ErrorMessage = "Zip code must not exceed 10 characters.")]
    [RegularExpression(@"^\d{4,10}$", ErrorMessage = "Zip code must contain only numbers and be between 4 and 10 digits.")]
    public string ZipCode { get; set; }

    [Required(ErrorMessage = "Relationship is required.")]
    [StringLength(50, ErrorMessage = "Relationship must not exceed 50 characters.")]
    [RegularExpression(@"^[A-Za-z\s'-]+$", ErrorMessage = "Relationship can only contain letters, spaces, hyphens, and apostrophes.")]
    public string Relationship { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number format.")]
    [StringLength(15, MinimumLength = 7, ErrorMessage = "Phone number must be between 7 and 15 digits.")]
    [RegularExpression(@"^\+?[0-9\s-]+$", ErrorMessage = "Phone number can only contain digits, spaces, dashes, and an optional leading +.")]
    public string PhoneNumber { get; set; }

    public ElderlyResident ElderlyResident { get; set; }

}
