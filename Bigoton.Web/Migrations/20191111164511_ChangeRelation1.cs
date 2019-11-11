using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bigoton.Web.Migrations
{
    public partial class ChangeRelation1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Reservations_ReservationId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_DiscountVouchers_DiscountVoucherId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ReservationId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Cut",
                table: "CutStyles");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiscountVoucherId",
                table: "Payments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Payments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_DiscountVouchers_DiscountVoucherId",
                table: "Payments",
                column: "DiscountVoucherId",
                principalTable: "DiscountVouchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_ClientId",
                table: "Reservations",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_DiscountVouchers_DiscountVoucherId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_ClientId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Payments");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountVoucherId",
                table: "Payments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cut",
                table: "CutStyles",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Clients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ReservationId",
                table: "Clients",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Reservations_ReservationId",
                table: "Clients",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_DiscountVouchers_DiscountVoucherId",
                table: "Payments",
                column: "DiscountVoucherId",
                principalTable: "DiscountVouchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
