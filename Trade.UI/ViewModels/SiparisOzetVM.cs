using Trade.DAL.Entities;
using Trade.UI.Models;

namespace Trade.UI.ViewModels
{
	public class SiparisOzetVM
	{
		public Siparis SiparisListesi { get; set; } // Sipariş bilgileri
		public List<Card> Cards { get; set; } // Sepet içeriği
        public List<Siparis> Siparisler { get; set; }
    }
}
