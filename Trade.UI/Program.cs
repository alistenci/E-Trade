using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Trade.BL.Repositories;
using Trade.DAL.Context;
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSession();
    builder.Services.AddDistributedMemoryCache();
    builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

    builder.Services.AddDbContext<SQLContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CS1")));
    builder.Services.AddScoped(typeof(IRepository<>), typeof(SQLRepositories<>));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    opt.LoginPath = "/account/Login"; // Yetkisi olmadan giriþ yapmaya çalýþýlýrsa yönleneceði sayfa
    opt.LogoutPath = "/account/LogOut"; // Çýkýþ yapýlýnca veya süre dolunca yönlendirilecek sayfa
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseStatusCodePagesWithRedirects("/hata/{0}");
}
app.UseStatusCodePagesWithReExecute("/Error/HttpStatusCodeHandler", "?StatusCode={0}");



app.UseStaticFiles();
    app.UseRouting();
    app.UseSession();

    app.UseAuthentication(); // kimlik doðrulama
    app.UseAuthorization(); // kimlik yetkilendirme


    app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    app.MapControllerRoute(name: "default", pattern: "{Controller=Home}/{Action=Index}/{id?}");

    //app.MapControllerRoute(
    //    name: "errorRoute",
    //    pattern: "hata/{statusCode}",
    //    defaults: new { controller = "Error", action = "HttpStatusCodeHandler" }
    //);
    //app.MapControllerRoute(
    //    name: "errorRoute",
    //    pattern: "errors/{action=Page404}/{id?}",
    //    defaults: new { controller = "Error" }
    //);




    app.Run();