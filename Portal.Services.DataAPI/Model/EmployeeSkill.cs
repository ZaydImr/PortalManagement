using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Services.DataAPI.Model;

[PrimaryKey("EmployeeId", "SkillId")]
public class EmployeeSkill
{
    public int EmployeeId { get; set; }
    public int SkillId { get; set; }

    [ForeignKey("EmployeeId")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public required Employee Employee { get; set; }

    [ForeignKey("SkillId")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public required Skill Skill { get; set; }

    public required int SkillLevel { get; set; }
}
