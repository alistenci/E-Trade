using Trade.DAL.Entities;

namespace Trade.UI.ViewModels
{
    public class UrunKategoriVM
    {
        public Urun Urun { get; set; }
        public List<UrunResimEklee> UrunResimler { get; set; }
    }
}
