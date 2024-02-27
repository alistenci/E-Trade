using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trade.BL.Repositories;
using Trade.DAL.Context;
using Trade.DAL.Entities;
using Trade.UI.Areas.admin.ViewModels;

namespace Trade.UI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class SiparisController : Controller
    {
        IRepository<Urun> repoUrun;
        IRepository<Siparis> repoSiparis;
        IRepository<Siparis_Detay> repoSiparisDetay;
        DbContext dbContext;
        public SiparisController(IRepository<Urun> repoUrun, IRepository<Siparis> repoSiparis, IRepository<Siparis_Detay> repoSiparisDetay)
        {
            this.repoUrun = repoUrun;
            this.repoSiparis = repoSiparis;
            this.repoSiparisDetay = repoSiparisDetay;
        }
        public IActionResult Index()
        {
            return View(repoSiparis.GetAll().OrderByDescending(x => x.SiparisID));
        }

        //public IActionResult GuncelleSiparis(string orderNumber)
        //{
        //    // Siparişi orderNumber'a göre bulun
        //    var siparis = repoSiparis.GetByOrderNumber(orderNumber);
        //    //var siparis = dbContext.Set<Siparis>().SingleOrDefault(s => s.OrderNumber == orderNumber);


        //    if (siparis == null)
        //    {
        //        // Sipariş bulunamadı, hata işleme veya başka bir işlem yapabilirsiniz.
        //        return RedirectToAction("Index");
        //    }

        //    // Enum seçeneklerini alın
        //    var siparisDurumlari = Enum.GetValues(typeof(SiparisDurumu)).Cast<SiparisDurumu>().Select(d => new SelectListItem
        //    {
        //        Text = d.ToString(),
        //        Value = d.ToString(),
        //        Selected = d == siparis.SiparisDurumu
        //    });

        //    // ViewModel oluşturun
        //    var viewModel = new SiparisGuncelleViewModel
        //    {
        //        Siparis = siparis,
        //        SiparisDurumlari = siparisDurumlari
        //    };

        //    return View(viewModel);
        //}


        //[HttpPost]
        //public IActionResult KaydetSiparis(Siparis siparis)
        //{
        //    // Siparişi veritabanından yeniden alın (bu güvenlik nedenleriyle yapılır)
        //    //var existingSiparis = repoSiparis.GetByOrderNumber(siparis.OrderNumber);
        //    var existingSiparis = repoSiparis.GetByOrderNumber(siparis.OrderNumber);

        //    if (existingSiparis == null)
        //    {
        //        // Sipariş bulunamadı, hata işleme veya başka bir işlem yapabilirsiniz.
        //        return RedirectToAction("Index");
        //    }

        //    existingSiparis.SiparisDurumu = siparis.SiparisDurumu;
        //    // Siparişi güncelleyin
        //    repoSiparis.Update(existingSiparis);

        //    return RedirectToAction("Index");
        //}


    }
}
