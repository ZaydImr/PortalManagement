using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Services.DataAPI.Model;

public class Skill
{
    [Column("Skill_Id")]
    public int SkillId { get; set; }
}
