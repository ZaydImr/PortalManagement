using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Services.DataAPI.Model;

public class JobTitle
{
    [Key]
    [Column("Job_Title_Id")]
    public int JobTitleId { get; set; }
    public required string Title { get; set; }
}
