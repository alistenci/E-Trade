using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trade.BL.Repositories;
using Trade.DAL.Entities;
using Trade.UI.Areas.admin.ViewModels;
using Trade.UI.ViewModels;
using Trade.DAL.Context;

namespace Trade.UI.Controllers
{
    public class ProductController : Controller
    {
        
        IRepository<Urun> repoUrun;
        IRepository<Slide> repoSlide;

        public ProductController(IRepository<Urun> _repoUrun, IRepository<Slide> repoSlide)
        {
            repoUrun = _repoUrun;
            this.repoSlide = repoSlide;
        }


        [Route("/urun/{name}-{id}")]
        public IActionResult Detail(string name, int id)
        {
            Urun urun = repoUrun.GetAll(x => x.ID == id).Include(x => x.Kategori).Include(x => x.UrunResimler).FirstOrDefault();
            if (urun != null)
            {
                ProductVM productVM = new ProductVM()
                {
                    Urun = urun,
                    RelatedProducts = repoUrun.GetAll(x => x.Kategori_Id == urun.Kategori_Id && x.ID != urun.ID).Include(x => x.UrunResimler)
                };
                return View(productVM);
            }
            else
            {
                return Redirect("/");

            }
        }


    }
}
