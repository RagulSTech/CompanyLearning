using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class Studentdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DStudentList",
                columns: table => new
                {
                    Stdid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StdName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StdAge = table.Column<int>(type: "int", nullable: false),
                    StdCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StdCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DStudentList", x => x.Stdid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DStudentList");
        }
    }
}
