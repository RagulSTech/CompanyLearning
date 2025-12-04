using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCoreAPI.Migrations.AppDbContextIdentityMigrations
{
    /// <inheritdoc />
    public partial class RemoveDepartmentFromEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "BEmployeesUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "BEmployeesUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
