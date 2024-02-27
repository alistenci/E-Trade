using Trade.DAL.Entities;

namespace Trade.UI.Areas.admin.ViewModels
{
    public class KategoriVM
    {
        public Kategori Kategori { get; set; }
        public IEnumerable<Kategori> Kategoriler { get; set; }
        public Urun Urunler { get; set; }
    }
}
