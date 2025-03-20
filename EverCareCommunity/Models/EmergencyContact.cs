
namespace EverCareCommunity.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;


public enum RelationshipType
{
    Parent,
    Child,
    Spouse,
    Sibling,
    Guardian,
    Friend,
    Other
}
public class EmergencyContact
{
    [Key]
    public int EmergencyContactID { get; set; }

    [ForeignKey("ElderlyResident")]
    public int ResidentID { get; set; }

    [ForeignKey("Address")]
    public int AddressID { get; set; }

    [ForeignKey("AddressID")]
    public Address Address { get; set; }

[Required(ErrorMessage = "First name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
    [RegularExpression(@"^[A-Za-z\s'-]+$", ErrorMessage = "First name can only contain letters, spaces, hyphens, and apostrophes.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
    [RegularExpression(@"^[A-Za-z\s'-]+$", ErrorMessage = "Last name can only contain letters, spaces, hyphens, and apostrophes.")]
    public string LastName { get; set; }

    public RelationshipType Relationship { get; set; }

    [Phone(ErrorMessage = "Invalid phone number format.")]
    [StringLength(15, MinimumLength = 7, ErrorMessage = "Phone number must be between 7 and 15 digits.")]
    [RegularExpression(@"^\+?[0-9\s-]+$", ErrorMessage = "Phone number can only contain digits, spaces, dashes, and an optional leading +.")]
    public string PhoneNumber { get; set; }



    public ElderlyResident ElderlyResident { get; set; }
    
}
