using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Services.DataAPI.Model;

public class Employee
{
    [Column("Employee_ID")]
    public int EmployeeID { get; set; }

    [Column("First_Name")]
    public required string FirstName { get; set; }

    [Column("Last_Name")]
    public required string LastName { get; set; }

    [Column("Professional_Email")]
    public required string ProfessionalEmail { get; set; }

    [Column("Personal_Email")]
    public string? PersonalEmail { get; set; }
    public string? Phone { get; set; }
    public required string Status { get; set; }

    [Column("Hire_Date")]
    public DateTime HireDate { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public required JobTitle JobTitle { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public required Department Department { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public required Employee Manager { get; set; }

    public required IEnumerable<EmployeeSalary> Salaries { get; set; }
    public required IEnumerable<EmployeeBankAccount> BankAccounts { get; set; }
    public required IEnumerable<EmployeeSkill> Skills { get; set; }
}
