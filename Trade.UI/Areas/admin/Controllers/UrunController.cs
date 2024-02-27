using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trade.BL.Repositories;
using Trade.DAL.Entities;
using Trade.UI.Areas.admin.ViewModels;

namespace Trade.UI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class UrunController : Controller
    {

		IRepository<Urun> repoUrun;
		IRepository<Kategori> repoKategori;
		IRepository<Marka> repoMarka;

        public UrunController(IRepository<Urun> _repoUrun, IRepository<Kategori> _repoKategori, IRepository<Marka> _repoMarka)
		{
			repoUrun = _repoUrun;
			repoKategori = _repoKategori;
			repoMarka = _repoMarka;
		}

        public IActionResult Index()
		{
            return View(repoUrun.GetAll().OrderByDescending(x => x.ID).Include(u => u.Kategori));
		}


		public IActionResult New()
		{
			UrunVM urunVM = new UrunVM()
			{
				Urun = new Urun(),
				Kategoriler = repoKategori.GetAll(x => x.ParentID != null).OrderBy(x => x.Name),
				Markalar = repoMarka.GetAll().OrderBy(x => x.Ad)
			};
			return View(urunVM);
		}

		[HttpPost, ValidateAntiForgeryToken]
        //public async Task<IActionResult> Insert(UrunVM model)
        //{
        //	if (ModelState.IsValid) // Gelen model doğrulanmışsa
        //	{
        //		repoUrun.Add(model.Urun);

        //		return RedirectToAction("Index");
        //	}
        //	else return RedirectToAction("New");
        //}


        public async Task<IActionResult> Insert(UrunVM model)
        {
            if (ModelState.IsValid)
            {
                // Ürün ekleme işlemleri

                // Ürün ekledikten sonra üst kategori bilgisini alıp ürün tablosuna atama
                var kategori = repoKategori.Get(model.Urun.Kategori_Id); // Kategori bilgisini getirin
                if (kategori != null)
                {
                    model.Urun.ustkategoribilgisi = kategori.ustkategoribilgisi;
                }

                repoUrun.Add(model.Urun);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("New");
            }
        }


        public IActionResult Edit(int id)
		{
			Urun urun = repoUrun.GetBy(x => x.ID == id);
			UrunVM urunVM = new UrunVM()
			{
				Urun = urun,
				Kategoriler = repoKategori.GetAll(x => x.ParentID != null).OrderBy(x => x.Name),
				Markalar = repoMarka.GetAll().OrderBy(x => x.Ad)
			};
			if (urun != null) return View(urunVM);
			else return RedirectToAction("Index");
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(UrunVM model)
		{
			if (ModelState.IsValid)
			{
				repoUrun.Update(model.Urun);
				return RedirectToAction("Index");
			}
			else return RedirectToAction("New");
		}


		public IActionResult Delete(int id)
		{
			Urun product = repoUrun.GetBy(x => x.ID == id);
			if (product != null) repoUrun.Delete(product);
			return RedirectToAction("Index");
		}

	}
}
