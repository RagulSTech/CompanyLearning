using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningCoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTestEfmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "TestlearnEF",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "TestlearnEF",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "TestlearnEF");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "TestlearnEF");
        }
    }
}
