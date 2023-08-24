using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Services.DataAPI.Model;

public class PerformanceReview
{
    [Key]
    [Column("Review_Id")]
    public int ReviewId { get; set; }

    [ForeignKey("Employee_Id")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public required Employee Employee { get; set; }

    [ForeignKey("SuperVisor_Id")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public required Employee SuperVisor { get; set; }

    public DateTime ReviewDate { get; set; }
    public required string Goals { get; set;}
    public required string Feedback { get; set; }
    public required int Rating { get; set; }

}