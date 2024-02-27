using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trade.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kullanici_Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ad_Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginIP = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kategoriler_Kategoriler_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Kategoriler",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Marka",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marka", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisID = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    TcNo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    E_Posta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "Slide",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slogan = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Picture = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Link = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slide", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Urun_Adi = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Urun_Aciklamasi = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Stok = table.Column<int>(type: "int", nullable: false),
                    Detay = table.Column<string>(type: "text", nullable: true),
                    KargoDetay = table.Column<string>(type: "text", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false),
                    Satici_Id = table.Column<int>(type: "int", nullable: false),
                    Kategori_Id = table.Column<int>(type: "int", nullable: false),
                    Urun_Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Indirim_Miktari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: true),
                    MarkaID = table.Column<int>(type: "int", nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Urunler_Kategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Urunler_Marka_MarkaID",
                        column: x => x.MarkaID,
                        principalTable: "Marka",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Kullaniciler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Kullanici_Adi = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Sifre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    E_Posta = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Telefon = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Eklenme_Tarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullaniciler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kullaniciler_Rols_RolID",
                        column: x => x.RolID,
                        principalTable: "Rols",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: true),
                    RecDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    District = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "Varchar(10)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: true),
                    MailAdress = table.Column<string>(type: "Varchar(80)", maxLength: 80, nullable: true),
                    NameSurname = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: true),
                    ShippedFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MusteriID = table.Column<int>(type: "int", nullable: true),
                    UrunID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Siparisler_Musteriler_MusteriID",
                        column: x => x.MusteriID,
                        principalTable: "Musteriler",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Siparisler_Urunler_UrunID",
                        column: x => x.UrunID,
                        principalTable: "Urunler",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UrunResimEklee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Resim = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false),
                    UrunID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunResimEklee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UrunResimEklee_Urunler_UrunID",
                        column: x => x.UrunID,
                        principalTable: "Urunler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler_Detay",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisID = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: true),
                    ProductPicture = table.Column<string>(type: "Varchar(150)", maxLength: 150, nullable: true),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UrunID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler_Detay", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Siparisler_Detay_Siparisler_SiparisID",
                        column: x => x.SiparisID,
                        principalTable: "Siparisler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Siparisler_Detay_Urunler_UrunID",
                        column: x => x.UrunID,
                        principalTable: "Urunler",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "ID", "Ad_Soyad", "Kullanici_Adi", "LastLoginDate", "LastLoginIP", "Sifre" },
                values: new object[] { 1, "Mehmet Ali", "ali", new DateTime(2023, 8, 29, 11, 41, 43, 295, DateTimeKind.Local).AddTicks(2604), "", "202cb962ac59075b964b07152d234b70" });

            migrationBuilder.CreateIndex(
                name: "IX_Kategoriler_ParentID",
                table: "Kategoriler",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullaniciler_RolID",
                table: "Kullaniciler",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_MusteriID",
                table: "Siparisler",
                column: "MusteriID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_UrunID",
                table: "Siparisler",
                column: "UrunID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_Detay_SiparisID",
                table: "Siparisler_Detay",
                column: "SiparisID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_Detay_UrunID",
                table: "Siparisler_Detay",
                column: "UrunID");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_KategoriID",
                table: "Urunler",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_MarkaID",
                table: "Urunler",
                column: "MarkaID");

            migrationBuilder.CreateIndex(
                name: "IX_UrunResimEklee_UrunID",
                table: "UrunResimEklee",
                column: "UrunID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Kullaniciler");

            migrationBuilder.DropTable(
                name: "Siparisler_Detay");

            migrationBuilder.DropTable(
                name: "Slide");

            migrationBuilder.DropTable(
                name: "UrunResimEklee");

            migrationBuilder.DropTable(
                name: "Rols");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Marka");
        }
    }
}
