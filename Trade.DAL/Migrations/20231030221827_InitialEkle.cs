using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trade.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialEkle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 10, 31, 1, 18, 26, 948, DateTimeKind.Local).AddTicks(1632));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 10, 25, 22, 32, 24, 768, DateTimeKind.Local).AddTicks(3014));
        }
    }
}
