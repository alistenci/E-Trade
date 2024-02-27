using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Trade.DAL.Entities;

namespace Trade.DAL.Context
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> opt) : base(opt)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>().HasOne(x => x.ParentCategory).WithMany(x => x.SubCategories).HasForeignKey(x => x.ParentID);

            modelBuilder.Entity<Urun>().HasOne(x => x.Kategori).WithMany(x => x.Urunler).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Urun>().HasOne(x => x.Marka).WithMany(x => x.Urunler).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<UrunResimEklee>().HasOne(x => x.Urun).WithMany(x => x.UrunResimler);


            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                ID = 1,
                Ad_Soyad = "Mehmet Ali",
                LastLoginDate = DateTime.Now,
                LastLoginIP = "",
                Kullanici_Adi = "ali",
                Sifre = "202cb962ac59075b964b07152d234b70", //md5 ile şifrelendi, şifre 123
            });
        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<AdminSiparis> Siparislerim { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Siparis_Detay> Siparisler_Detay { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kullanici> Kullaniciler { get; set; }
        public DbSet<Slide> Slide {get; set; }
        public DbSet<Marka> Marka {get; set; }
        public DbSet<UrunResimEklee> UrunResimEklee {get; set; }
    }
}
