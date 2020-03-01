using Identity.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    /*
     * NuGet ile kurmamız gereken paketler;
     * - Microsoft.AspNet.Identity.EntityFramework
     * - Microsoft.AspNet.Identity.Owin
     * - Microsoft.Owin.Host.SystemWeb
     * Identity kullanırken yapılması gerekenler;
     * - IdentityConfig(OwinStartup) classını oluştur
     * - Web.config altında IdentityConfig dosyanı tanıt
     * - IdentityUser ve IdentityRole sınıflarını miras alarak Custom class'larını oluştur
     * - IdentityDbContext sınıfını miras alarak Custom Context sınıfını oluştur
     * - Controller'ında userManager nesnelerini oluştur
     */
    [Authorize(Roles = "Admin")] // Controller seviyesinde Admin rolüne sahip olan kullanıcı bu controller'a erişebilir dedik
    public class AdminController : Controller
    {
        private UserManager<MyUser> _userManager; // Kullanıcı işlemleri için bir UserManager oluşturmalıyız. Generictir ve bizden Custom oluşturduğumuz User modeli bekler
        public AdminController()
        {
            _userManager = new UserManager<MyUser>(new UserStore<MyUser>(new IdentityDataContext())); // UserManager bir UserStore (Custom user modeli generic alır) bekler ve UserStore'da bir Context bekler
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(_userManager.Users); // bütün user'ları view'a gönderiyoruz
        }
    }
}