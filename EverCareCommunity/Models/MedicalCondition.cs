namespace EverCareCommunity.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MedicalCondition
{
    [Key]
    public int ConditionID { get; set; }

    [ForeignKey("ElderlyResident")]
    public int ResidentID { get; set; }

    [Required, StringLength(100)]
    public string ConditionName { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    public ElderlyResident ElderlyResident { get; set; }


}