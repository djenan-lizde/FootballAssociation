using Microsoft.EntityFrameworkCore.Migrations;

namespace Transfermarkt.WebAPI.Migrations
{
    public partial class ChangeContractPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSigned",
                table: "Players",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "Contracts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSigned",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "Contracts");
        }
    }
}
