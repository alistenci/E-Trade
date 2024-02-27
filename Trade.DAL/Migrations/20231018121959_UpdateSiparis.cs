using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trade.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSiparis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Siparisler");

            migrationBuilder.RenameColumn(
                name: "ShippedFee",
                table: "Siparisler",
                newName: "ToplamUcret");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Siparisler",
                newName: "Il");

            migrationBuilder.AddColumn<string>(
                name: "AcikAdres",
                table: "Siparisler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ilce",
                table: "Siparisler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 10, 18, 15, 19, 59, 398, DateTimeKind.Local).AddTicks(3509));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcikAdres",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "Ilce",
                table: "Siparisler");

            migrationBuilder.RenameColumn(
                name: "ToplamUcret",
                table: "Siparisler",
                newName: "ShippedFee");

            migrationBuilder.RenameColumn(
                name: "Il",
                table: "Siparisler",
                newName: "Country");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Siparisler",
                type: "Varchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 10, 17, 2, 18, 8, 922, DateTimeKind.Local).AddTicks(1150));
        }
    }
}
