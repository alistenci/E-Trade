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
    public class Kategori
    {
        public int ID { get; set; }
        public int? ParentID { get; set; }
        public Kategori ParentCategory { get; set; }
        public ICollection<Kategori> SubCategories { get; set; }

        [Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Kategori Adı")]
        public string Name { get; set; }

        [Display(Name = "Görüntülenme Sırası")]
        public int DisplayIndex { get; set; }
        public string ustkategoribilgisi { get; set; }
        public ICollection<Urun> Urunler { get; set; }
    }
}
