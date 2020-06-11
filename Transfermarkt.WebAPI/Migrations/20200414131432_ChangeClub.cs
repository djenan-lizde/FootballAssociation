using Microsoft.EntityFrameworkCore.Migrations;

namespace Transfermarkt.WebAPI.Migrations
{
    public partial class ChangeClub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Leagues_LeagueId",
                table: "Clubs");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_LeagueId",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "Clubs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeagueId",
                table: "Clubs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_LeagueId",
                table: "Clubs",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Leagues_LeagueId",
                table: "Clubs",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
