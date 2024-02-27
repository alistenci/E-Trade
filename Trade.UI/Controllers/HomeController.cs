using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using Trade.BL.Repositories;
using Trade.DAL.Entities;
using Trade.UI.Filter;
using Trade.UI.ViewModels;

namespace Trade.UI.Controllers
{
    [UserFilter]
    public class HomeController : Controller
    {
        
        IRepository<Slide> repoSlide;
        IRepository<Urun> repoUrun;
        IRepository<Kategori> repoKategori;
        public HomeController(IRepository<Slide> _repoSlide, IRepository<Urun> repoUrun, IRepository<Kategori> repoKategori)
        {
            repoSlide = _repoSlide;
            this.repoUrun = repoUrun;
            this.repoKategori = repoKategori;

        }
        public IActionResult Index()
        {
            IndexVM indexVM = new IndexVM()
            {
                Slides = repoSlide.GetAll().OrderBy(x => x.DisplayIndex),
                LastestProduct = repoUrun.GetAll().Include(x => x.UrunResimler).OrderBy(x => x.ID).Take(8),
                SalesProduct = repoUrun.GetAll().Include(x => x.UrunResimler).OrderBy(x => Guid.NewGuid()).Take(8)
            };
            return View(indexVM);
        }
    }
}