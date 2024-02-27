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
    public class Kullanici
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Ad"), Required(ErrorMessage = "Ad Boş Geçilemez")]
        public string Ad { get; set; }
        [Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Soyad"), Required(ErrorMessage = "Soyad Boş Geçilemez")]
        public string Soyad { get; set; }
        [Column(TypeName = "varchar(20)"), StringLength(20), Display(Name = "Kullanıcı Adı"), Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        public string Kullanici_Adi { get; set; }
        [Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Şifre"), Required(ErrorMessage = "Şifre Boş Geçilemez")]
        public string Sifre { get; set; }
        [Column(TypeName = "varchar(30)"), StringLength(30), Display(Name = "E-Posta"), Required(ErrorMessage = "E-Posta Boş Geçilemez")]
        public string E_Posta { get; set; }
        [Column(TypeName = "varchar(20)"), StringLength(20), Display(Name = "Telefon Numarası"), Required(ErrorMessage = "Telefon numarası Boş Geçilemez")]
        public string Telefon { get; set; }
        public DateTime Eklenme_Tarihi { get; set; }
        public int RolID { get; set; }
        [Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Adres"), Required(ErrorMessage = "Adres Boş Geçilemez")]
        public virtual Rol Rol { get; set; }
    }
}
