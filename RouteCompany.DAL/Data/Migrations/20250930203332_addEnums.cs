using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouteCompany.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class addEnums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "Employee gender - Male or Female");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeType",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldComment: "Employee type - Parttime or Fulltime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "Employee gender - Male or Female",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeType",
                table: "Employees",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                comment: "Employee type - Parttime or Fulltime",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
