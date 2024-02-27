using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Trade.BL.Repositories;
using Trade.DAL.Context;
using Trade.DAL.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Trade.UI.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Trade.UI.Tools;
using NuGet.Protocol.Plugins;
using Trade.UI.Models;

namespace Trade.UI.Controllers
{
    public class AccountController : Controller
    {
		//private readonly IRepository<Kullanici> kullanici;
		//private readonly IRepository<User> user;
		private readonly SQLContext _context;

		public AccountController(/*IRepository<Kullanici> kullanici, IRepository<User> user, */SQLContext context)
		{
			//this.kullanici = kullanici;
			//this.user = user;
			_context = context;
		}

        //public IActionResult Index()
        //{

        //	return View();
        //}

        //public IActionResult Login(string eMail, string Sifre)
        //{
        //	var user = _context.Users.FirstOrDefault(w => w.eMail.Equals(eMail) && w.Sifre.Equals(Sifre));
        //	if (user != null)
        //	{
        //		HttpContext.Session.SetInt32("id", user.Id);
        //		HttpContext.Session.SetString("fullname", user.Ad + " " + user.Soyad);
        //		return Redirect("/Home");
        //	}
        //	return Redirect("Index");
        //}


        //public async Task<IActionResult> Login(KullaniciLoginVM loginVM)
        //{
        //    try
        //    {
        //        var user = await _context.Users.FirstOrDefaultAsync(w => w.eMail.Equals(loginVM.eMail));

        //        if (user != null && user.Sifre == loginVM.Sifre)
        //        {
        //            HttpContext.Session.SetInt32("id", user.Id);
        //            HttpContext.Session.SetString("fullname", user.Ad + " " + user.Soyad);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            // Kullanıcı doğrulama başarısız
        //            ModelState.AddModelError(string.Empty, "Geçersiz e-posta veya şifre");
        //            return View(loginVM);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return View(loginVM);
        //    }
        //}



        ////[HttpPost]
        //public async Task<IActionResult> Login(User u)
        //{
        //    var bilgiler = _context.Users.FirstOrDefault(x => x.eMail == u.eMail && x.Sifre == u.Sifre);
        //    if (bilgiler != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, u.kullaniciAdi)
        //        };
        //        var userId = new ClaimsIdentity(claims, "a");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(userId);
        //        await HttpContext.SignInAsync(principal);
        //        return RedirectToAction("Login", "Account");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }

        //}




        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(KullaniciLoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.SingleOrDefault(u => u.eMail == model.eMail && u.Sifre == model.Sifre);

                if (user != null)
                {
                    HttpContext.Session.SetInt32("id", user.Id);
                    HttpContext.Session.SetString("fullname", user.Ad + " " + user.Soyad);
                    var claims = new List<Claim>
            {
                new Claim("Username", user.kullaniciAdi),
                new Claim(ClaimTypes.Name, user.Soyad),
            };

                    var claimsIdentity = new ClaimsIdentity(
                        claims,
                        CookieAuthenticationDefaults.AuthenticationScheme
                    );

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe // Oturumu kalıcı hale getirme seçeneği
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );

                    if (user.RolId == Rol.Kullanici)
                    {
                        return RedirectToAction("Index", "Home");

                    }
                    else if (user.RolId == Rol.Admin)
                    {
                        return RedirectToAction("Index" , "Admin");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre");
                }
            }

            return View(model); // Geçersiz giriş durumunda giriş formunu tekrar görüntüle
        }





        //public async Task<IActionResult> LogOut()
        //{
        //    await HttpContext.SignOutAsync();
        //    return RedirectToAction("Index", "Home");
        //}

        public async Task<IActionResult> LogOut()
        {
            // Oturumu kapat
            await HttpContext.SignOutAsync();

            // Kullanıcı kimlik doğrulama çerezlerini sil
            if (Request.Cookies.ContainsKey("Identity.Application"))
            {
                Response.Cookies.Delete("Identity.Application");
            }

            if (Request.Cookies.ContainsKey("Identity.External"))
            {
                Response.Cookies.Delete("Identity.External");
            }

            // Diğer çerezleri de gerektiğinde sil

            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignUp()
        {
			return View();
		}

        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                model.RolId = Rol.Kullanici;
                // Doğrulama başarılı, kullanıcıyı kaydet ve başka bir sayfaya yönlendir.
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Account");

            }
            return View("SignUp", model);

        }

    }
}
