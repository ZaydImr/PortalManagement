using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Services.DataAPI.Model;

public class Department
{

    [Key]
    [Column("Department_ID")]
    public int DepartmentID { get; set; }

    [Column("Department_Name")]
    public required string Name { get; set; }

    //public required Employee Manager { get; set; }

}
