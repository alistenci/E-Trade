using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trade.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSiparislerimmm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SiparisId",
                table: "Siparislerim",
                newName: "SiparisDurumu");

            migrationBuilder.AddColumn<string>(
                name: "SiparisNumarasi",
                table: "Siparislerim",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminSiparisId",
                table: "Siparisler_Detay",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Siparisler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ePosta",
                table: "Siparisler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 10, 17, 2, 18, 8, 922, DateTimeKind.Local).AddTicks(1150));

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_Detay_AdminSiparisId",
                table: "Siparisler_Detay",
                column: "AdminSiparisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Siparisler_Detay_Siparislerim_AdminSiparisId",
                table: "Siparisler_Detay",
                column: "AdminSiparisId",
                principalTable: "Siparislerim",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siparisler_Detay_Siparislerim_AdminSiparisId",
                table: "Siparisler_Detay");

            migrationBuilder.DropIndex(
                name: "IX_Siparisler_Detay_AdminSiparisId",
                table: "Siparisler_Detay");

            migrationBuilder.DropColumn(
                name: "SiparisNumarasi",
                table: "Siparislerim");

            migrationBuilder.DropColumn(
                name: "AdminSiparisId",
                table: "Siparisler_Detay");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "ePosta",
                table: "Siparisler");

            migrationBuilder.RenameColumn(
                name: "SiparisDurumu",
                table: "Siparislerim",
                newName: "SiparisId");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 10, 16, 12, 42, 30, 494, DateTimeKind.Local).AddTicks(7566));
        }
    }
}
