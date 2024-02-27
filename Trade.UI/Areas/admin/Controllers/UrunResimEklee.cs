using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trade.BL.Repositories;
using Trade.DAL.Entities;

namespace Trade.UI.Areas.admin.Controllers
{
    #region Validation Yapılması Gereken Ayar
    // jquery.validate.min.js dosyasında
    // (?:,\d{3})+)? (?:\.\d +)?$/.test(a)
    // arat ve o kısmı 
    // (?:.\d{3})+)? (?:\,\d +)?$/.test(a) olarak değiştir
    #endregion
    [Area("admin"), Authorize]
    public class UrunResimEkleeController : Controller
    {
        IRepository<UrunResimEklee> repoUrunResimEklee;
        public UrunResimEkleeController(IRepository<UrunResimEklee> _repoUrunResimEklee)
        {
            repoUrunResimEklee = _repoUrunResimEklee;
        }
        public IActionResult Index(int urunid)
        {
            ViewBag.UrunId = urunid;
            return View(repoUrunResimEklee.GetAll(x => x.UrunID == urunid).OrderByDescending(x => x.ID));
        }


        public IActionResult New(int urunid)
        {
            ViewBag.UrunId = urunid;
            return View();
        }


        //[HttpPost, ValidateAntiForgeryToken]
        //public async Task<IActionResult> Insert(UrunResimEklee model)
        //{
        //    if (ModelState.IsValid) // Gelen model doğrulanmışsa
        //    {
        //        if (Request.Form.Files.Any())
        //        {
        //            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "urunresimler"))) // söylenen konumda belirtilen dosyayı arıyor
        //            {
        //                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "urunresimler")); // dosyayı oluşturuyor
        //            }
        //            string dosyaAdi = Request.Form.Files["Resim"].FileName;
        //            using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "urunresimler", dosyaAdi), FileMode.Create))
        //            {
        //                await Request.Form.Files["Resim"].CopyToAsync(stream);
        //            }
        //            model.Resim = "/img/urunresimler/" + dosyaAdi;
        //        }

        //        repoUrunResimEklee.Add(model);

        //        return RedirectToAction("Index", new { urunid = model.UrunID });
        //    }
        //    else return RedirectToAction("New");
        //}


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(UrunResimEklee model)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Any())
                {
                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "urunresimler")))
                    {
                        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "urunresimler"));
                    }
                    string dosyaAdi = Request.Form.Files["Resim"].FileName;
                    using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "urunresimler", dosyaAdi), FileMode.Create))
                    {
                        await Request.Form.Files["Resim"].CopyToAsync(stream);
                    }
                    model.Resim = "/img/urunresimler/" + dosyaAdi;

                    // Set the UrunID for the image
                    model.UrunID = model.UrunID;
                }

                repoUrunResimEklee.Add(model);

                return RedirectToAction("Index", new { urunid = model.UrunID });
            }
            else return RedirectToAction("New");
        }




        public IActionResult Edit(int id)
        {
            UrunResimEklee slide = repoUrunResimEklee.GetBy(x => x.ID == id);
            if (slide != null) return View(slide);
            else return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UrunResimEklee model)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Any())
                {
                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "urunresimler"))) // söylenen konumda belirtilen dosyayı arıyor
                    {
                        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "urunresimler")); // dosyayı oluşturuyor
                    }
                    string dosyaAdi = Request.Form.Files["Resim"].FileName;
                    using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "urunresimler", dosyaAdi), FileMode.Create))
                    {
                        await Request.Form.Files["Resim"].CopyToAsync(stream);
                    }
                    model.Resim = "/img/urunresimler/" + dosyaAdi;
                }
                repoUrunResimEklee.Update(model);
                return RedirectToAction("Index", new { urunid = model.UrunID });
            }
            else return RedirectToAction("New");
        }


        public IActionResult Delete(int id)
        {
            UrunResimEklee slide = repoUrunResimEklee.GetBy(x => x.ID == id);
            if (slide != null) repoUrunResimEklee.Delete(slide);
            return RedirectToAction("Index", new { urunid = id });
        }

    }
}
