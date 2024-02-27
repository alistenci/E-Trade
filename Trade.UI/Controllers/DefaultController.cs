using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trade.BL.Repositories;
using Trade.DAL.Context;
using Trade.DAL.Entities;
using Trade.UI.Areas.admin.ViewModels;
using Trade.UI.ViewModels;

namespace Trade.UI.Controllers
{
    public class DefaultController : Controller
    {
        IRepository<Urun> repoUrun;
        IRepository<UrunResimEklee> repoUrunresimekle;
        public DefaultController(IRepository<Urun> repoUrun, IRepository<UrunResimEklee> repoUrunresimekle)
        {
            this.repoUrun = repoUrun;
            this.repoUrunresimekle = repoUrunresimekle;
        }
        [HttpGet]
        [Route("tumurunler")]
        public IActionResult Index()
        {
            // Ürün resimleri ve ürün bilgilerini aldım
            var urunResimler = repoUrunresimekle.GetAll();
            var urunlerim = repoUrun.GetAll();

            
            var urunlerViewModel = new List<UrunlerimVM>(); // UrunViewModel listesi oluşturdum

            
            var list = urunResimler.ToList();
            foreach (var urunResim in list) // Her bir ürün resmi ile ilgili ürün bilgisini birleştirme
            {
                var urun = urunlerim.FirstOrDefault(u => u.ID == urunResim.UrunID);

                if (urun != null)
                {
                    var urunViewModel = new UrunlerimVM
                    {
                        Resimler = urunResim,
                        Urunum = urun
                    };

                    if (!urunlerViewModel.Any(uv => uv.Urunum.ID == urunViewModel.Urunum.ID))
                    {
                        urunlerViewModel.Add(urunViewModel);
                    }
                }
            }
            return View(urunlerViewModel);
        }
        public IActionResult Urunler(int kategoriId)
        {
            

            //return View(urunler);

            // Ürün resimleri ve ürün bilgilerini aldım
            var urunResimler = repoUrunresimekle.GetAll();
            var urunler = repoUrun.GetAll().Where(u => u.Kategori_Id == kategoriId).ToList(); // Kategoriye göre ürünlerin listelendiği ve beni gereksiz yere uğraştıran kod - 2


            var urunlerViewModel = new List<UrunlerimVM>(); // UrunViewModel listesi oluşturdum


            var list = urunResimler.ToList(); // ???
            foreach (var urunResim in list) // Her bir ürün resmi ile ilgili ürün bilgisini birleştirme
            {
                var urun = urunler.FirstOrDefault(u => u.ID == urunResim.UrunID);

                if (urun != null)
                {
                    var urunViewModel = new UrunlerimVM
                    {
                        Resimler = urunResim,
                        Urunum = urun
                    };

                    if (!urunlerViewModel.Any(uv => uv.Urunum.ID == urunViewModel.Urunum.ID))
                    {
                        urunlerViewModel.Add(urunViewModel);
                    }
                }
            }
            return View(urunlerViewModel);

            //// Kategoriye ait ürün resimleri ve ürün bilgilerini aldım
            //var urunResimler = repoUrunresimekle.GetAll();
            //var urunlerim = repoUrun.GetAll();

            //var urunlerViewModel = new List<UrunlerimVM>(); // UrunViewModel listesi oluşturdum

            //// Yalnızca belirli bir parent ID'ye sahip olan ürünleri filtreleme
            //var urunlerFiltrelenmis = urunlerim.Where(u => u.Kategori_Id == kategoriId);

            //foreach (var urun in urunlerFiltrelenmis)
            //{
            //    
            //    var urunResim = urunResimler.FirstOrDefault(r => r.UrunID == urun.ID);

            //    if (urunResim != null)
            //    {
            //        var urunViewModel = new UrunlerimVM
            //        {
            //            Resimler = urunResim,
            //            Urunum = urun
            //        };

            //        if (!urunlerViewModel.Any(uv => uv.Urunum.ID == urunViewModel.Urunum.ID))
            //        {
            //            urunlerViewModel.Add(urunViewModel);
            //        }
            //    }
            //}
            //return View(urunlerViewModel);



            //// Belirli bir kategoriye ait ürünleri ve resimleri al
            //var urunler = repoUrun.GetAll().Where(u => u.ParentID == kategoriId).ToList();
            //var urunIds = urunler.Select(u => u.ID).ToList();
            //var urunResimler = repoUrunresimekle.GetAll().Where(r => urunIds.Contains(r.UrunID)).ToList();

            //// Ürünleri ve resimleri ViewModel içinde birleştir
            //var kategoriUrunlerVM = new List<UrunKategoriVM>();

            //foreach (var urun in urunler)
            //{
            //    var urunResimList = urunResimler.Where(r => r.UrunID == urun.ID).ToList();
            //    var kategoriUrunVM = new UrunKategoriVM
            //    {
            //        Urun = urun,
            //        UrunResimler = urunResimList
            //    };
            //    kategoriUrunlerVM.Add(kategoriUrunVM);
            //}

            //return View(kategoriUrunlerVM);
        }
    }
}
