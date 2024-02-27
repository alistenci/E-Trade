using Microsoft.AspNetCore.Mvc.Rendering;
using Trade.DAL.Entities;

namespace Trade.UI.Areas.admin.ViewModels
{
    public class SiparisGuncelleViewModel
    {
        public Siparis Siparis { get; set; }
        public IEnumerable<SelectListItem> SiparisDurumlari { get; set; }
    }
}
