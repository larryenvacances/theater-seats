using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Boilerplate.Infrastructure.Migrations
{
    public partial class TheaterIdTimeSlot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TheaterId",
                table: "TimeSlots",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_TheaterId",
                table: "TimeSlots",
                column: "TheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_Theaters_TheaterId",
                table: "TimeSlots",
                column: "TheaterId",
                principalTable: "Theaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_Theaters_TheaterId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_TheaterId",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "TheaterId",
                table: "TimeSlots");
        }
    }
}
