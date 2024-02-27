using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Trade.DAL.Entities;
using Trade.UI.Tools;
using Trade.BL.Repositories;
using Trade.UI.Areas.admin.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Trade.UI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class HomeController : Controller
    {
        private readonly IRepository<Admin> repoAdmin;
        private readonly IRepository<User> repoUser;

        public HomeController(IRepository<Admin> _repoAdmin, IRepository<User> _repoUser)
        {
            repoAdmin = _repoAdmin;
            repoUser = _repoUser;
        }

        public IActionResult Index()
        {
            return View(repoUser.GetAll().OrderByDescending(x => x.Id));
        }

        public IActionResult Guncelle(int id)
        {
            // Kullanıcıyı veritabanından bul
            var kullanici = repoUser.Get(id);

            if (kullanici == null)
            {
                // Kullanıcı bulunamadı
                return RedirectToAction("Index");
            }

            // Enum seçenekleri
            var roller = Enum.GetValues(typeof(Rol)).Cast<Rol>().Select(r => new SelectListItem
            {
                Text = r.ToString(),
                Value = ((int)r).ToString(),
                Selected = r == kullanici.RolId
            });

            var viewModel = new RolGuncelleViewModel
            {
                Kullanici = kullanici,
                Roller = roller
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Kaydet(User kullanici)
        {
            // Kullanıcıyı veritabanından yeniden al - sebebi güvenlik???
            var existingUser = repoUser.Get(kullanici.Id);

            if (existingUser == null)
            {
                // Kullanıcı bulunamadı
                return RedirectToAction("Index");
            }

            existingUser.RolId = kullanici.RolId;
            // Kullanıcıyı güncelle
            repoUser.Update(existingUser);

            return RedirectToAction("Index");
        }








        [AllowAnonymous, Route("/admin/login")]
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
		[AllowAnonymous, Route("/admin/login"), HttpPost, ValidateAntiForgeryToken] // Authorize ile kilitlediğimiz controller içerisindeki belirtilen action'a erişime izin ver.
		public async Task<IActionResult> Login(string username, string password, string ReturnUrl)
		{
			string md5Password = GeneralTools.GetMD5(password);
			Admin admin = repoAdmin.GetBy(x => x.Kullanici_Adi == username && x.Sifre == md5Password);
			if (admin != null)
			{
				List<Claim> claims = new List<Claim>
				{
					new Claim(ClaimTypes.PrimarySid, admin.ID.ToString()),
					new Claim(ClaimTypes.Name, admin.Ad_Soyad)
				};
				ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "TradeAuth");
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties() { IsPersistent = true });
				if (!string.IsNullOrEmpty(ReturnUrl)) return Redirect(ReturnUrl);
				return Redirect("/admin");
			}
			else TempData["bilgi"] = "Yanlış kullanıcı adı veya parola!";
			return RedirectToAction("Login");
		}
		[Route("admin/logout")]
		public async Task<IActionResult> LogOut()
		{
			await HttpContext.SignOutAsync();
			return Redirect("/");
		}
	}
}
