using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Boilerplate.Infrastructure.Migrations
{
    public partial class FKInEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Theaters_TheaterEntityId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_TimeSlots_TimeSlotId",
                table: "Reservations");

            migrationBuilder.AlterColumn<Guid>(
                name: "TimeSlotId",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TheaterEntityId",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Theaters_TheaterEntityId",
                table: "Reservations",
                column: "TheaterEntityId",
                principalTable: "Theaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_TimeSlots_TimeSlotId",
                table: "Reservations",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Theaters_TheaterEntityId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_TimeSlots_TimeSlotId",
                table: "Reservations");

            migrationBuilder.AlterColumn<Guid>(
                name: "TimeSlotId",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "TheaterEntityId",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Theaters_TheaterEntityId",
                table: "Reservations",
                column: "TheaterEntityId",
                principalTable: "Theaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_TimeSlots_TimeSlotId",
                table: "Reservations",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
