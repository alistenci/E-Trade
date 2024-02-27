using Trade.DAL.Entities;

namespace Trade.UI.Areas.admin.ViewModels
{
    public class UrunVM
    {
        public Urun Urun { get; set; }
        public IEnumerable<Kategori> Kategoriler { get; set; }
        public IEnumerable<Marka> Markalar { get; set; }
    }
}
