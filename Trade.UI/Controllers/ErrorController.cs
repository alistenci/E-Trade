using Microsoft.AspNetCore.Mvc;

namespace Trade.UI.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error/HttpStatusCodeHandler")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return View("Page404");
                case 500:
                    return View("500");
                case 405:
                    return View("405");
                case 400:
                    return View("400");
                default:
                    return View("Error"); // Diğer hata durumları
            }
        }


        //public IActionResult Page404()
        //{
        //    return View();
        //}
    }
}
