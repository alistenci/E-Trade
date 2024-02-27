using Trade.DAL.Entities;
using Trade.UI.Models;

namespace Trade.UI.ViewModels
{
    public class SatisKontrolVM
    {
        public Siparis Siparis { get; set; }
        public IEnumerable<Card> Cards { get; set; }
        public IEnumerable<Siparis> Siparisler { get; set; }
		public Urun Urun { get; set; }
    }
}
