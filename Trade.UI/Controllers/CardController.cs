using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;
using Trade.BL.Repositories;
using Trade.DAL.Entities;
using Trade.UI.Filter;
using Trade.UI.Models;
using Trade.UI.ViewModels;

namespace Trade.UI.Controllers
{
    public class CardController : Controller
    {
        IRepository<Urun> repoUrun;
        IRepository<Siparis> repoSiparis;
		IRepository<Siparis_Detay> repoSiparisDetay;
		IRepository<User> repoKullanici;

		public CardController(IRepository<Urun> _repoUrun, IRepository<Siparis> _repoSiparis, IRepository<Siparis_Detay> _repoSiparisDetay, IRepository<User> _repoKullanici)
        {
            repoUrun = _repoUrun;
            repoSiparis = _repoSiparis;
            repoSiparisDetay = _repoSiparisDetay;
            repoKullanici = _repoKullanici;
		}
        [Route("/sepet/sepeteekle"), HttpPost]
        public string AddCard(int urunid, int miktar)
        {
            Urun product = repoUrun.GetAll(x => x.ID == urunid).Include(x => x.UrunResimler).FirstOrDefault();
            bool varmi = false;
            if (product != null)
            {
                string resim = "";
                if (product.UrunResimler.Count == 0)
                    resim = "/img/hazirlaniyor.png";
                else
                    resim = product.UrunResimler.FirstOrDefault().Resim;
                Card card = new Card()
                {
                    UrunID = urunid,
                    UrunAdi = product.Urun_Adi,
                    UrunResmi = resim,
                    UrunFiyat = product.Urun_Fiyat,
                    Miktar = miktar
                };
                List<Card> cards = new List<Card>();
                if (Request.Cookies["MyCard"] != null) // daha önce sepete ürün eklendiyse
                {
                    cards = JsonConvert.DeserializeObject<List<Card>>(Request.Cookies["MyCard"]);
                    foreach (Card c in cards)
                    {
                        if (c.UrunID == urunid)
                        {
                            varmi = true;
                            if (c.UrunID == urunid) c.Miktar += miktar;
                            break;

                        }

                    }
                }
                if (!varmi)
                    cards.Add(card);

                CookieOptions option = new();
                option.Expires = DateTime.Now.AddHours(3);
                Response.Cookies.Append("MyCard", JsonConvert.SerializeObject(cards), option);
                return product.Urun_Adi;
            }

            return "~ Ürün Bulunamadı";
        }

        [Route("/sepet/sepetsayisi")]
        public int CardCount()
        {
            int geri = 0;
            if (Request.Cookies["MyCard"] != null)
            {
                List<Card> carts = JsonConvert.DeserializeObject<List<Card>>(Request.Cookies["MyCard"]);
                geri = carts.Sum(x => x.Miktar);
            }
            return geri;
        }

        [Route("/sepet")]
        public IActionResult Index()
        {
            if (Request.Cookies["MyCard"] != null)
            {
                CardVM cartVm = new CardVM()
                {
                    Cards = JsonConvert.DeserializeObject<List<Card>>(Request.Cookies["MyCard"]),
                    //BestSelling = repoProduct.GetAll().Include(x => x.ProductPictures).OrderByDescending(x => x.SumQuantity).Take(4)
                };
                return View(cartVm);
            }
            else
            {
                return Redirect("/");
            }
        }
        [Route("/sepet/alisverisitamamla")]
        [UserFilter]
        public IActionResult CheckOut()
        {
            ViewBag.ShippingFee = 1000;
            if (Request.Cookies["MyCard"] != null)
            {
                List<Card> carts = JsonConvert.DeserializeObject<List<Card>>(Request.Cookies["MyCard"]);
                SatisKontrolVM satisKontrolVM = new SatisKontrolVM()
                {
                    Siparis = new Siparis(),
                    Cards = carts
                };
                return View(satisKontrolVM);
            }
            else
            {
                return Redirect("/");
            }
        }

		[Route("/sepet/alisverisitamamla"), HttpPost, ValidateAntiForgeryToken]
		public IActionResult CheckOut(SatisKontrolVM model)
		{
			if (ModelState.IsValid)
			{
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				model.Siparis.RecDate = DateTime.Now;
				string orderNumber = DateTime.Now.Millisecond.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Millisecond.ToString();
				if (orderNumber.Length > 20) orderNumber = orderNumber.Substring(0, 20);
				model.Siparis.OrderNumber = orderNumber;
				model.Siparis.SiparisDurumu = SiparisDurumu.Hazirlaniyor;

				List<Card> carts = JsonConvert.DeserializeObject<List<Card>>(Request.Cookies["MyCard"]);
				foreach (Card c in carts)
				{
					// Her bir ürün için sipariş nesnesini oluştur
					Siparis od = new Siparis()
					{
						// Sipariş ile ilgili bilgileri doldur
						SiparisID = model.Siparis.ID,
						OrderNumber = orderNumber,
						UrunID = c.UrunID,
						ProductName = c.UrunAdi,
						ProductPicture = c.UrunResmi,
						ProductPrice = c.UrunFiyat,
						Quantity = c.Miktar,
						NameSurname = model.Siparis.NameSurname,
						OdemeSecenegi = model.Siparis.OdemeSecenegi,
						Il = model.Siparis.Il,
						Ilce = model.Siparis.Ilce,
						Phone = model.Siparis.Phone,
						MailAdress = model.Siparis.MailAdress,
						ToplamUcret = model.Siparis.ToplamUcret,
						AcikAdres = model.Siparis.AcikAdres,
                        RecDate = model.Siparis.RecDate,
					};
					repoSiparis.Add(od);
				}

				// Tek bir sipariş nesnesini veritabanına ekleyin
				//repoSiparis.Add(model.Siparis);

				Response.Cookies.Delete("MyCart");

				return Redirect("/Card/SiparisOzet");
			}
			else
			{
				return View(model);
			}
		}


		[Route("/sepet/sepettensil"), HttpPost]
        public string RemoveCard(int urunid)
        {
            string rtn = "";
            if (Request.Cookies["MyCard"] != null)
            {
                List<Card> cards = JsonConvert.DeserializeObject<List<Card>>(Request.Cookies["MyCard"]);
                bool varMi = false;
                foreach (Card c in cards)
                {
                    if (c.UrunID == urunid)
                    {
                        varMi = true;
                        cards.Remove(c);
                        break;
                    }
                }
                if (varMi)
                {
                    CookieOptions options = new();
                    options.Expires = DateTime.Now.AddHours(3);
                    Response.Cookies.Append("MyCard", JsonConvert.SerializeObject(cards), options);
                    rtn = "OK";

                }

            }

            return rtn;
        }

        [Route("/sepet/siparisozet"), HttpPost, ValidateAntiForgeryToken]
        public IActionResult SiparisOzet(SatisKontrolVM model)
        {
			if (Request.Cookies["MyCard"] != null)
			{
				List<Card> carts = JsonConvert.DeserializeObject<List<Card>>(Request.Cookies["MyCard"]);
				SatisKontrolVM satisKontrolVM = new SatisKontrolVM()
				{
					Siparis = new Siparis(),
					Cards = carts
				};
				return View(satisKontrolVM);
			}
			else
			{
				return Redirect("/");
			}
		}

		public IActionResult SiparisOzet()
		{
			if (Request.Cookies["MyCard"] != null)
			{
				// Son eklenen siparişin OrderNumberını almak için kullandım
				string sonOrderNumber = repoSiparis.GetAll().OrderByDescending(x => x.ID).Select(x => x.OrderNumber).FirstOrDefault();


				// Son eklenen siparişin OrderNumberına sahip tüm siparişleri getir
				List<Siparis> siparisler = repoSiparis.GetAll(x => x.OrderNumber == sonOrderNumber).ToList();


				// İlgili siparişleri bir view modeline doldur
				SiparisOzetVM siparisOzetVM = new SiparisOzetVM()
				{
					SiparisListesi = siparisler.FirstOrDefault(), // İlk siparişi aldım, çünkü tüm siparişler aynı OrderNumbera sahip
                    Siparisler = siparisler,
					Cards = JsonConvert.DeserializeObject<List<Card>>(Request.Cookies["MyCard"]),
				};

				return View(siparisOzetVM);
			}
			else
			{
				return Redirect("/");
			}
		}

	}
}