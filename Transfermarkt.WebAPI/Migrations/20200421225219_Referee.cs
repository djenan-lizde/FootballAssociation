using Microsoft.EntityFrameworkCore.Migrations;

namespace Transfermarkt.WebAPI.Migrations
{
    public partial class Referee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Referees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referees_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RefereeMatches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(nullable: false),
                    RefereeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefereeMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefereeMatches_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RefereeMatches_Referees_RefereeId",
                        column: x => x.RefereeId,
                        principalTable: "Referees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefereeMatches_MatchId",
                table: "RefereeMatches",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_RefereeMatches_RefereeId",
                table: "RefereeMatches",
                column: "RefereeId");

            migrationBuilder.CreateIndex(
                name: "IX_Referees_CityId",
                table: "Referees",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefereeMatches");

            migrationBuilder.DropTable(
                name: "Referees");
        }
    }
}
