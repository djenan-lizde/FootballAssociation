using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Transfermarkt.WebAPI.Migrations
{
    public partial class NewInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubsLeague_Clubs_ClubId",
                table: "ClubsLeague");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubsLeague_Leagues_LeagueId",
                table: "ClubsLeague");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubsLeague_Seasons_SeasonId",
                table: "ClubsLeague");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_ClubsLeague_AwayClubId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_ClubsLeague_HomeClubId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_ClubsLeague_ClubId",
                table: "ClubsLeague");

            migrationBuilder.DropIndex(
                name: "IX_ClubsLeague_LeagueId",
                table: "ClubsLeague");

            migrationBuilder.DropIndex(
                name: "IX_ClubsLeague_SeasonId",
                table: "ClubsLeague");

            migrationBuilder.AddColumn<int>(
                name: "LeagueId",
                table: "Matches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Matches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "LastUpdate",
                table: "ClubsLeague",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LeagueId",
                table: "Matches",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SeasonId",
                table: "Matches",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Clubs_AwayClubId",
                table: "Matches",
                column: "AwayClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Clubs_HomeClubId",
                table: "Matches",
                column: "HomeClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Leagues_LeagueId",
                table: "Matches",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Seasons_SeasonId",
                table: "Matches",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Clubs_AwayClubId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Clubs_HomeClubId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Leagues_LeagueId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Seasons_SeasonId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_LeagueId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_SeasonId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "ClubsLeague");

            migrationBuilder.CreateIndex(
                name: "IX_ClubsLeague_ClubId",
                table: "ClubsLeague",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubsLeague_LeagueId",
                table: "ClubsLeague",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubsLeague_SeasonId",
                table: "ClubsLeague",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubsLeague_Clubs_ClubId",
                table: "ClubsLeague",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ClubsLeague_Leagues_LeagueId",
                table: "ClubsLeague",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ClubsLeague_Seasons_SeasonId",
                table: "ClubsLeague",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_ClubsLeague_AwayClubId",
                table: "Matches",
                column: "AwayClubId",
                principalTable: "ClubsLeague",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_ClubsLeague_HomeClubId",
                table: "Matches",
                column: "HomeClubId",
                principalTable: "ClubsLeague",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
