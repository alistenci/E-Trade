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
    public class Musteri
    {
        public int ID { get; set; }
        public int SiparisID { get; set; }
        [Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Ad"), Required(ErrorMessage = "Ad Boş Geçilemez")]
        public string Ad { get; set; }
        [Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Soyad"), Required(ErrorMessage = "Soyad Boş Geçilemez")]
        public string Soyad { get; set; }
        [Column(TypeName = "varchar(20)"), StringLength(20), Display(Name = "Kullanıcı Adı"), Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        public string TcNo { get; set; }
        public string E_Posta { get; set; }
        [Column(TypeName = "varchar(20)"), StringLength(20), Display(Name = "Telefon Numarası"), Required(ErrorMessage = "Telefon numarası Boş Geçilemez")]
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public ICollection<Siparis> Siparisler { get; set; } // Bir müşterinin birden fazla siparişi olabilir
    }
}
