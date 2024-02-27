using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trade.BL.Repositories;
using Trade.DAL.Entities;

namespace Trade.UI.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        IRepository<Kategori> repoKategori;
        public HeaderViewComponent(IRepository<Kategori> _repoKategori)
        {
            repoKategori = _repoKategori;
        }
        public IViewComponentResult Invoke()
        {
            return View(repoKategori.GetAll().Include(x => x.SubCategories).OrderByDescending(x => x.ID));
        }
    }
}
