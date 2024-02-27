using Trade.DAL.Entities;

namespace Trade.UI.ViewModels
{
    public class ProductVM
    {
        public Urun Urun { get; set; }
        public IEnumerable<Urun> RelatedProducts { get; set; }
    }
}
