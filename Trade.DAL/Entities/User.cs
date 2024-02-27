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
		public class User
		{
			public int Id { get; set; }
			[Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Ad"), Required(ErrorMessage = "Ad Boş Geçilemez")]
			public string Ad { get; set; }
			[Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Soyad"), Required(ErrorMessage = "Soyad Boş Geçilemez")]
			public string Soyad { get; set; }
			[Column(TypeName = "varchar(20)"), StringLength(20), Display(Name = "Kullanıcı Adı"), Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
			public string kullaniciAdi { get; set; }
			[Column(TypeName = "varchar(30)"), StringLength(30), Display(Name = "E-Posta"), Required(ErrorMessage = "E-Posta Boş Geçilemez")]
			public string eMail { get; set; }
			[Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Şifre"), Required(ErrorMessage = "Şifre Boş Geçilemez")]
			public string Sifre { get; set; }
		    public Rol RolId { get; set; }
            public Rol Roller { get; set; }
    }
}
