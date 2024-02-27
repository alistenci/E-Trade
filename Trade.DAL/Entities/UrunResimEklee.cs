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
    public class UrunResimEklee
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Ürün Resim Adı")]
        public string Ad { get; set; }

        [Column(TypeName = "varchar(150)"), StringLength(150), Display(Name = "Resim Dosyası")]
        public string Resim { get; set; }

        [Display(Name = "Görüntülenme Sırası")]
        public int DisplayIndex { get; set; }

        [Display(Name = "Ürün Adı")]
        public int UrunID { get; set; }
        public Urun Urun { get; set; }
    }
}
