using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Portal.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class insertRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "auth",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                schema: "auth",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1625481a-9645-4e74-be48-0ffbe96bcc7e", null, "ROLE_ADMIN", "ROLE_ADMIN" },
                    { "43ce8e05-2c6f-46c2-8a40-bbc9deff274e", null, "ROLE_RH", "ROLE_RH" },
                    { "6d1ccb25-9d65-4472-a3dd-6b63e90c4d69", null, "ROLE_EMPLOYEE", "ROLE_EMPLOYEE" },
                    { "d1c1100e-4355-41fd-83d7-3378750e8f48", null, "ROLE_SUPER_ADMIN", "ROLE_SUPER_ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1625481a-9645-4e74-be48-0ffbe96bcc7e");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43ce8e05-2c6f-46c2-8a40-bbc9deff274e");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d1ccb25-9d65-4472-a3dd-6b63e90c4d69");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1c1100e-4355-41fd-83d7-3378750e8f48");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "auth",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
