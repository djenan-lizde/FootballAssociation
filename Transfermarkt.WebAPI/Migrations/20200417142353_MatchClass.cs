using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Transfermarkt.WebAPI.Migrations
{
    public partial class MatchClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateGame = table.Column<DateTime>(nullable: false),
                    GameStart = table.Column<string>(nullable: true),
                    GameEnd = table.Column<string>(nullable: true),
                    IsFinished = table.Column<bool>(nullable: false),
                    StadiumId = table.Column<int>(nullable: false),
                    HomeClubId = table.Column<int>(nullable: false),
                    AwayClubId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_ClubsLeague_AwayClubId",
                        column: x => x.AwayClubId,
                        principalTable: "ClubsLeague",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Matches_ClubsLeague_HomeClubId",
                        column: x => x.HomeClubId,
                        principalTable: "ClubsLeague",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Matches_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayClubId",
                table: "Matches",
                column: "AwayClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeClubId",
                table: "Matches",
                column: "HomeClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_StadiumId",
                table: "Matches",
                column: "StadiumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
