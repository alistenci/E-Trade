using Trade.DAL.Entities;

namespace Trade.UI.ViewModels
{
    public class IndexVM
    {
        public IEnumerable<Slide> Slides { get; set; }
        public IEnumerable<Urun> LastestProduct { get; set; }
        public IEnumerable<Urun> SalesProduct { get; set; }
    }
}
