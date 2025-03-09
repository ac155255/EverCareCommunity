namespace EverCareCommunity.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CaregiverResidentAssignment
{
    [Key]
    public int AssignmentID { get; set; }

    [ForeignKey("Caregiver")]
    public int CaregiverID { get; set; }

    [ForeignKey("ElderlyResident")]
    public int ResidentID { get; set; }

    [MaxLength(500)]
    public string Notes { get; set; }

    public Caregiver Caregiver { get; set; }
    public ElderlyResident ElderlyResident { get; set; }
}
