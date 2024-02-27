using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trade.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserMu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    kullaniciAdi = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    eMail = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Sifre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 10, 3, 22, 31, 19, 725, DateTimeKind.Local).AddTicks(9748));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 10, 3, 22, 18, 37, 739, DateTimeKind.Local).AddTicks(5530));
        }
    }
}
