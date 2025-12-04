using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCoreAPI.Migrations.AppDbContextIdentityMigrations
{
    /// <inheritdoc />
    public partial class addColumnsFromEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Employeerollno",
                table: "BEmployeesUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Employeerollno",
                table: "BEmployeesUsers");
        }
    }
}
