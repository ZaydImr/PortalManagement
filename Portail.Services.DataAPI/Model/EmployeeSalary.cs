using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Services.DataAPI.Model;

[PrimaryKey("EmployeeId", "ApplyDate")]
public class EmployeeSalary
{
    public int EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public required Employee Employee { get; set; }


    public required DateTime ApplyDate { get; set; }

    public required double Salary { get; set; }
}
