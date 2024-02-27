using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trade.UI.ViewModels
{
    public class KullaniciLoginVM
    {
        public string eMail { get; set; }
        [Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Şifre"), Required(ErrorMessage = "Şifre Boş Geçilemez")]
        public string Sifre { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
