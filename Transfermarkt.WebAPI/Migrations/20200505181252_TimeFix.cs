using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Transfermarkt.WebAPI.Migrations
{
    public partial class TimeFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "MatchDetails");

            migrationBuilder.AddColumn<int>(
                name: "Minute",
                table: "MatchDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Minute",
                table: "MatchDetails");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "MatchDetails",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
