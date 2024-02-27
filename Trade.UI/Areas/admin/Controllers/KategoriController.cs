using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trade.BL.Repositories;
using Trade.DAL.Entities;
using Trade.UI.Areas.admin.ViewModels;

namespace Trade.UI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class KategoriController : Controller
    {
        IRepository<Kategori> repoKategori;
        IRepository<Urun> repoUrun;
        public KategoriController(IRepository<Kategori> _repoKategori, IRepository<Urun> repoUrun)
        {
            repoKategori = _repoKategori;
            this.repoUrun = repoUrun;
        }
        public IActionResult Index()
        {
            return View(repoKategori.GetAll().Include(x => x.ParentCategory).OrderByDescending(x => x.ID));
        }
        public IActionResult New()
        {
            KategoriVM kategoriVM = new KategoriVM()
            {
                Kategori = new Kategori(),
                Kategoriler = repoKategori.GetAll().OrderBy(x => x.Name)
            };
            return View(kategoriVM);
        }
        //public async Task<IActionResult> Insert(KategoriVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repoKategori.Add(model.Kategori);
        //        return RedirectToAction("Index");
        //    }
        //    else return RedirectToAction("New");
        //}
        public async Task<IActionResult> Insert(KategoriVM model)
        {
            if (ModelState.IsValid)
            {
                // Check if there is a parent category selected
                if (model.Kategori.ParentID.HasValue)
                {
                    var ustKategori = repoKategori.Get(model.Kategori.ParentID.Value);
                    if (ustKategori != null)
                    {
                        model.Kategori.ustkategoribilgisi = ustKategori.Name;
                    }
                }

                repoKategori.Add(model.Kategori);
                return RedirectToAction("Index");
            }

            // If ModelState is not valid, return back to the New view with errors
            model.Kategoriler = repoKategori.GetAll().OrderBy(x => x.Name);
            return View("New", model);
        }


        public IActionResult Edit(int id)
        {
            Kategori kategori = repoKategori.GetBy(x => x.ID == id);
            KategoriVM categoryVM = new KategoriVM()
            {
                Kategori = kategori,
                Kategoriler = repoKategori.GetAll().OrderBy(x => x.Name)
            };
            if (kategori != null) return View(categoryVM);
            else return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(KategoriVM model)
        {
            if (ModelState.IsValid)
            {
                repoKategori.Update(model.Kategori);
                return RedirectToAction("Index");
            }
            else return RedirectToAction("New");
        }


        public IActionResult Delete(int id)
        {
            //Category category = repoCategory.GetBy(x => x.ID == id);
            //if (category != null) repoCategory.Delete(category);
            //return RedirectToAction("Index");


            Kategori category = repoKategori.GetBy(x => x.ID == id);
            if (category != null) repoKategori.Delete(category);
            return RedirectToAction("Index");
        }

    }
}