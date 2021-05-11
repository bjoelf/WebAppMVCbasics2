using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppMVCbasics2app.Migrations
{
    public partial class AddedCityObjectChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_LiveInCityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "City",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "LiveInCityId",
                table: "People",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_People_LiveInCityId",
                table: "People",
                newName: "IX_People_CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "People",
                newName: "LiveInCityId");

            migrationBuilder.RenameIndex(
                name: "IX_People_CityId",
                table: "People",
                newName: "IX_People_LiveInCityId");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "People",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_LiveInCityId",
                table: "People",
                column: "LiveInCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
