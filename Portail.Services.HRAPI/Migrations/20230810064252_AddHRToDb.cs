using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portal.Services.HRAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddHRToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HumanResource",
                columns: table => new
                {
                    HR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HR_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HR_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumanResource", x => x.HR_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HumanResource");
        }
    }
}
