using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Trade.UI.Filter
{
    public class UserFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? userId = context.HttpContext.Session.GetInt32("id");
            string controllerName = context.RouteData.Values["controller"].ToString();
            string actionName = context.RouteData.Values["action"].ToString();

            // Kullanıcı giriş yapmamışsa ve Siparişi Tamamla eylemi CardController içindeyse
            if (!userId.HasValue && controllerName == "Card" && actionName == "CheckOut")
            {
                // Kullanıcıyı login sayfasına yönlendir
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
            {
                {"action", "Login" },
                {"controller", "Account" }
            });
            }

            base.OnActionExecuting(context);
        }
    } 
}
