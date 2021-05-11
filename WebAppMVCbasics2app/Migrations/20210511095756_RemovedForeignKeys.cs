using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppMVCbasics2app.Migrations
{
    public partial class RemovedForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_People_PersonInCityId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Cities_CityInCountryId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CityInCountryId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Cities_PersonInCityId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CityInCountryId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "PersonInCityId",
                table: "Cities");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_CityId",
                table: "People",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Cities");

            migrationBuilder.AddColumn<int>(
                name: "CityInCountryId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonInCityId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CityInCountryId",
                table: "Countries",
                column: "CityInCountryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_PersonInCityId",
                table: "Cities",
                column: "PersonInCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_People_PersonInCityId",
                table: "Cities",
                column: "PersonInCityId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Cities_CityInCountryId",
                table: "Countries",
                column: "CityInCountryId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
