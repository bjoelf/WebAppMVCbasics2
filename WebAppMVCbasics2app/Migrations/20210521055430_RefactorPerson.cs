using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppMVCbasics2app.Migrations
{
    public partial class RefactorPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "People",
                newName: "ForName");

            migrationBuilder.AddColumn<DateTime>(
                name: "DayOfBirth",
                table: "People",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfBirth",
                table: "People");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "ForName",
                table: "People",
                newName: "Name");
        }
    }
}
