using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Services.DataAPI.Model;

[PrimaryKey("EmployeeId", "RIB")]
public class EmployeeBankAccount
{
    public int EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public required Employee Employee { get; set; }

    [Key]
    public required string RIB { get; set; }

    public DateTime AddedDate { get; set; }
    public required string Status { get; set; }
}
