using Microsoft.EntityFrameworkCore.Migrations;

namespace Transfermarkt.WebAPI.Migrations
{
    public partial class RemovingCityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Cities_BirthplaceId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_BirthplaceId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "BirthplaceId",
                table: "Players");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BirthplaceId",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Players_BirthplaceId",
                table: "Players",
                column: "BirthplaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Cities_BirthplaceId",
                table: "Players",
                column: "BirthplaceId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
