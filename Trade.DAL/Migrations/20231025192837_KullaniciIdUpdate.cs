using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trade.DAL.Migrations
{
    /// <inheritdoc />
    public partial class KullaniciIdUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KullaniciId",
                table: "Siparisler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 10, 25, 22, 28, 37, 559, DateTimeKind.Local).AddTicks(2619));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "Siparisler");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 10, 25, 15, 9, 55, 377, DateTimeKind.Local).AddTicks(8344));
        }
    }
}
