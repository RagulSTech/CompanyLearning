using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class Employeelistdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpDetails_data",
                columns: table => new
                {
                    empid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    empname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empcity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empage = table.Column<int>(type: "int", nullable: false),
                    empposition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpDetails_data", x => x.empid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpDetails_data");
        }
    }
}
