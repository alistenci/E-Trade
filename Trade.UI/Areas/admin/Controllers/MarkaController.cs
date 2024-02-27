using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;
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
	public class MarkaController : Controller
	{
		IRepository<Marka> repoMarka;
		public MarkaController(IRepository<Marka> _repoMarka)
		{
			repoMarka = _repoMarka;
		}
		public IActionResult Index()
		{
			return View(repoMarka.GetAll().OrderByDescending(x => x.ID));
		}


		public IActionResult New()
		{
			return View();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Insert(Marka model)
		{
			if (ModelState.IsValid) // Gelen model doğrulanmışsa
			{
				repoMarka.Add(model);

				return RedirectToAction("Index");
			}
			else return RedirectToAction("New");
		}

		public IActionResult Edit(int id)
		{
			Marka brand = repoMarka.GetBy(x => x.ID == id);
			if (brand != null) return View(brand);
			else return RedirectToAction("Index");
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Marka model)
		{
			if (ModelState.IsValid)
			{
				repoMarka.Update(model);
				return RedirectToAction("Index");
			}
			else return RedirectToAction("New");
		}


		public IActionResult Delete(int id)
		{
			Marka brand = repoMarka.GetBy(x => x.ID == id);
			if (brand != null) repoMarka.Delete(brand);
			return RedirectToAction("Index");
		}

	}
}
