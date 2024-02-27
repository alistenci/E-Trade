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
    public class AdminSiparis
    {
        public int Id { get; set; }
        public string Ad_Soyad { get; set; }
        public string ePosta { get; set; }
        public string Telefon { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public int PostaKodu { get; set; }
        public int ToplamFiyat { get; set; }
        public string AcikAdres { get; set; }
        public int UrunId { get; set; }
        public int MusteriId { get; set; }
        public string OdemeSecenegi { get; set; }
        public string SiparisNumarasi { get; set; }
		public SiparisDurumu SiparisDurumu { get; set; }
		public DateTime SiparisTarihi { get; set; }
        public Urun Urun { get; set; }
        public User Musteri { get; set; }
		public ICollection<Siparis_Detay> SiparisDetayi { get; set; }

		[NotMapped]
		public string CartNumber { get; set; }
		[NotMapped]
		public string CartMonth { get; set; }
		[NotMapped]
		public string CartYear { get; set; }
		[NotMapped]
		public string CartCV2 { get; set; }

	}
}
