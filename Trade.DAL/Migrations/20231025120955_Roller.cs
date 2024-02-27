using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trade.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Roller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kullaniciler_Rols_RolID",
                table: "Kullaniciler");

            migrationBuilder.DropTable(
                name: "Rols");

            migrationBuilder.DropIndex(
                name: "IX_Kullaniciler_RolID",
                table: "Kullaniciler");

            migrationBuilder.AddColumn<int>(
                name: "Roller",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Kullaniciler",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 10, 25, 15, 9, 55, 377, DateTimeKind.Local).AddTicks(8344));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roller",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Kullaniciler");

            migrationBuilder.CreateTable(
                name: "Rols",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rols", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastLoginDate",
                value: new DateTime(2023, 10, 18, 16, 43, 59, 562, DateTimeKind.Local).AddTicks(6404));

            migrationBuilder.CreateIndex(
                name: "IX_Kullaniciler_RolID",
                table: "Kullaniciler",
                column: "RolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kullaniciler_Rols_RolID",
                table: "Kullaniciler",
                column: "RolID",
                principalTable: "Rols",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
