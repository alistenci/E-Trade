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
    public class Siparis_Detay
    {
        public int ID { get; set; }
        [Display(Name = "Sipariş Numarası")]
        public int SiparisID { get; set; }
        public Siparis Siparis { get; set; }

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
