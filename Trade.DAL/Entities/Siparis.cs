using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.DAL.Entities
{
    public class Siparis
    {
        public int ID { get; set; }
        [Column(TypeName = "Varchar(20)"), StringLength(20), Display(Name = "Sipariş Numarası")]
        public string OrderNumber { get; set; }
        [Display(Name = "Ödeme Seçeneği")]
        public OdemeSecenegi OdemeSecenegi { get; set; }

        [Display(Name = "Sipariş Durumu")]
        public SiparisDurumu SiparisDurumu { get; set; }

        [Display(Name = "Sipariş Tarihi")]
        public DateTime RecDate { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string AcikAdres { get; set; }

        [Column(TypeName = "Varchar(20)"), StringLength(20), Display(Name = "Telefon Numarası")]
        public string Phone { get; set; }
        [Column(TypeName = "Varchar(80)"), StringLength(80), Display(Name = "Mail Adresi")]
        public string MailAdress { get; set; }

        [Column(TypeName = "Varchar(100)"), StringLength(100), Display(Name = "Adı Soyadı")]
        public string NameSurname { get; set; }

        [Column(TypeName = "decimal(18,2)"), Display(Name = "Toplam Ücret")]
        public decimal ToplamUcret { get; set; }

        public ICollection<Siparis_Detay> SiparisDetayi { get; set; }

        [NotMapped]
        public string CartNumber { get; set; }
        [NotMapped]
        public string CartMonth { get; set; }
        [NotMapped]
        public string CartYear { get; set; }
        [NotMapped]
        public string CartCV2 { get; set; }
        [Display(Name = "Sipariş Numarası")]
        public int SiparisID { get; set; }
        public string KullaniciId { get; set; }

        [Column(TypeName = "Varchar(100)"), StringLength(100), Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }

        [Column(TypeName = "Varchar(150)"), StringLength(150), Display(Name = "Ürün Resmi")]
        public string ProductPicture { get; set; }
        [Column(TypeName = "decimal(18,2)"), Display(Name = "Ürün Fiyatı")]
        public decimal ProductPrice { get; set; }
        [Display(Name = "Miktar")]
        public int Quantity { get; set; }

        [Display(Name = "Ürün Adı")]
        public int? UrunID { get; set; }
        public Urun Urun { get; set; }
    }
}
