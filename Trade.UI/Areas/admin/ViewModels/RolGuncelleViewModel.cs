using Microsoft.AspNetCore.Mvc.Rendering;
using Trade.DAL.Entities;

namespace Trade.UI.Areas.admin.ViewModels
{
    public class RolGuncelleViewModel
    {
        public User Kullanici { get; set; }
        public IEnumerable<SelectListItem> Roller { get; set; }
    }
}
