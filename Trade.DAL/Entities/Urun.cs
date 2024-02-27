using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Trade.DAL.Entities
{
    public class Urun
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(20)"), StringLength(20), Display(Name = "Ürün Adı"), Required(ErrorMessage = "Ürün Adı Boş Geçilemez")]
        public string Urun_Adi { get; set; }
        [Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Ürün Açıklaması"), Required(ErrorMessage = "Ürün Açıklaması Boş Geçilemez")]
        public string Urun_Aciklamasi { get; set; }
        [Display(Name = "Stok Miktarı")]
        public int Stok { get; set; }
        [Column(TypeName = "text"), Display(Name = "Ürün Detayı")]
        public string Detay { get; set; }
        [Column(TypeName = "text"), Display(Name = "Ürün Kargo Detayı")]
        public string KargoDetay { get; set; }
        [Display(Name = "Görüntülenme Sırası")]
        public int DisplayIndex { get; set; }
        public int Satici_Id { get; set; }
        [Display(Name = "Kategori Adı")]
        public int Kategori_Id { get; set; }
        [Column(TypeName = "decimal(18,2)"), Display(Name = "Fiyat Bilgisi")]
        public decimal Urun_Fiyat { get; set; }
        [Column(TypeName = "decimal(18,2)"), Display(Name = "İndirim Miktarı")]
        public decimal Indirim_Miktari { get; set; }
        public ICollection<Siparis> Siparisler { get; set; } // Bir ürünü birden fazla kez sipariş verebilirler
        public Kategori Kategori { get; set; }
        public int SumQuantity { get; set; }

        [Display(Name = "Marka Adı")]
		public int? MarkaID { get; set; }
		public Marka Marka { get; set; }
        public int? ParentID { get; set; }
        public string ustkategoribilgisi { get; set; }

        public ICollection<UrunResimEklee> UrunResimler { get; set; }


        public Urun()
        {
            if (Kategori != null && Kategori.ParentCategory != null)
            {
                ustkategoribilgisi = Kategori.ParentCategory.ustkategoribilgisi;
            }
        }
    }
}
