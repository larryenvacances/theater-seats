using Microsoft.EntityFrameworkCore.Migrations;

namespace Boilerplate.Infrastructure.Migrations
{
    public partial class RemoveUselessProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Theaters_TheaterId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "TheaterId",
                table: "Reservations",
                newName: "TheaterEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_TheaterId",
                table: "Reservations",
                newName: "IX_Reservations_TheaterEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Theaters_TheaterEntityId",
                table: "Reservations",
                column: "TheaterEntityId",
                principalTable: "Theaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Theaters_TheaterEntityId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "TheaterEntityId",
                table: "Reservations",
                newName: "TheaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_TheaterEntityId",
                table: "Reservations",
                newName: "IX_Reservations_TheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Theaters_TheaterId",
                table: "Reservations",
                column: "TheaterId",
                principalTable: "Theaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
