using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Portal.Services.DataAPI.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "data");

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "data",
                columns: table => new
                {
                    Department_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Department_ID);
                });

            migrationBuilder.CreateTable(
                name: "JobTitle",
                schema: "data",
                columns: table => new
                {
                    Job_Title_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitle", x => x.Job_Title_Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                schema: "data",
                columns: table => new
                {
                    Skill_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Skill_Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "data",
                columns: table => new
                {
                    Employee_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Professional_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personal_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hire_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobTitleId = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    ManagerEmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Employee_ID);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalSchema: "data",
                        principalTable: "Department",
                        principalColumn: "Department_ID");
                    table.ForeignKey(
                        name: "FK_Employee_Employee_ManagerEmployeeID",
                        column: x => x.ManagerEmployeeID,
                        principalSchema: "data",
                        principalTable: "Employee",
                        principalColumn: "Employee_ID");
                    table.ForeignKey(
                        name: "FK_Employee_JobTitle_JobTitleId",
                        column: x => x.JobTitleId,
                        principalSchema: "data",
                        principalTable: "JobTitle",
                        principalColumn: "Job_Title_Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeBankAccount",
                schema: "data",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RIB = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBankAccount", x => new { x.EmployeeId, x.RIB });
                    table.ForeignKey(
                        name: "FK_EmployeeBankAccount_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "data",
                        principalTable: "Employee",
                        principalColumn: "Employee_ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalary",
                schema: "data",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalary", x => new { x.EmployeeId, x.ApplyDate });
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "data",
                        principalTable: "Employee",
                        principalColumn: "Employee_ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkill",
                schema: "data",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    SkillLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkill", x => new { x.EmployeeId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "data",
                        principalTable: "Employee",
                        principalColumn: "Employee_ID");
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "data",
                        principalTable: "Skill",
                        principalColumn: "Skill_Id");
                });

            migrationBuilder.CreateTable(
                name: "PerformanceReview",
                schema: "data",
                columns: table => new
                {
                    Review_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_Id = table.Column<int>(type: "int", nullable: false),
                    SuperVisor_Id = table.Column<int>(type: "int", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Goals = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceReview", x => x.Review_Id);
                    table.ForeignKey(
                        name: "FK_PerformanceReview_Employee_Employee_Id",
                        column: x => x.Employee_Id,
                        principalSchema: "data",
                        principalTable: "Employee",
                        principalColumn: "Employee_ID");
                    table.ForeignKey(
                        name: "FK_PerformanceReview_Employee_SuperVisor_Id",
                        column: x => x.SuperVisor_Id,
                        principalSchema: "data",
                        principalTable: "Employee",
                        principalColumn: "Employee_ID");
                });

            migrationBuilder.InsertData(
                schema: "data",
                table: "Department",
                columns: new[] { "Department_ID", "Department_Name" },
                values: new object[,]
                {
                    { 1, "IT / Support" },
                    { 2, "Technician" },
                    { 3, "Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentID",
                schema: "data",
                table: "Employee",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobTitleId",
                schema: "data",
                table: "Employee",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ManagerEmployeeID",
                schema: "data",
                table: "Employee",
                column: "ManagerEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_SkillId",
                schema: "data",
                table: "EmployeeSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceReview_Employee_Id",
                schema: "data",
                table: "PerformanceReview",
                column: "Employee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceReview_SuperVisor_Id",
                schema: "data",
                table: "PerformanceReview",
                column: "SuperVisor_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeBankAccount",
                schema: "data");

            migrationBuilder.DropTable(
                name: "EmployeeSalary",
                schema: "data");

            migrationBuilder.DropTable(
                name: "EmployeeSkill",
                schema: "data");

            migrationBuilder.DropTable(
                name: "PerformanceReview",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Skill",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "data");

            migrationBuilder.DropTable(
                name: "JobTitle",
                schema: "data");
        }
    }
}
