using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.DAL.Entities
{
    public enum OdemeSecenegi
    {
        [Display(Name = "Kredi Kartı ile Ödeme")]
        KrediKarti=1,
		[Display(Name = "Havale/EFT ile Ödeme")]
        Havale,
		[Display(Name = "Kapıda Nakit/Kredi Kartı ile Ödeme")]
        KapidaOdeme 
    }
}
