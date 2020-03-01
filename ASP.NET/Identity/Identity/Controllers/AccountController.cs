using Identity.Identity;
using Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    [Authorize] // Django'daki @login_required decorator'un aynısı. İster Controller ister Action seviyesinde yazabiliriz. Login olmadan Bu Attr ile işaretlenmiş Controller/Action'lara ulaşılamaz ve login olmak için IdentityConfig altında belirlediğimiz LoginPath'e redirect olur
    public class AccountController : Controller
    {
        private UserManager<MyUser> _userManager; // Kullanıcı işlemleri için bir UserManager oluşturmalıyız. Generictir ve bizden Custom oluşturduğumuz User modeli bekler
        public AccountController()
        {
            _userManager = new UserManager<MyUser>(new UserStore<MyUser>(new IdentityDataContext())); // UserManager bir UserStore (Custom user modeli generic alır) bekler ve UserStore'da bir Context bekler
            _userManager.PasswordValidator = new CustomPasswordValidator() // şifre doğrulama yöntemi ekliyoruz(opsiyonel)
                                                                           // _userManager.PasswordValidator = new PasswordValidator() // şifre doğrulama yöntemi ekliyoruz(opsiyonel)
            {
                RequireDigit = true, // parolada mutlaka sayı olmalı
                RequiredLength = 7, // parola minimum 7 karakter olmalı
                RequireLowercase = true, // mutlaka küçük harf olmalı
                RequireUppercase = true, // mutlaka büyük harf olmalı
                RequireNonLetterOrDigit = true // mutlaka alpha numeric bir değer olmalı (. - / @ vs.)
            };
            _userManager.UserValidator = new UserValidator<MyUser>(_userManager)
            {
                RequireUniqueEmail = true, // unique mail adresleri oldu
                AllowOnlyAlphanumericUserNames = false // aplha-numeric karakter olsun mu olmasın mı
            };
        }

        public ActionResult Index()
        {
            return View();
        }


        [AllowAnonymous] // Bu controller'da Authorize'i controller seviyesinde yazdık fakat Register Action'da zaten login olmamış bir kullanıcı görmeli bu yüzden AllowAnonymous yaptık. Bu sayede Login olmamış kullanıcılar Register Action'a ulaşabilecek
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(RegisterAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new MyUser();
                user.Email = model.Email;
                user.UserName = model.Username;
                var result = _userManager.Create(user, model.Password); // usermanager'İn create fonksiyonu çalışır. bizden bir *CustomUser bekler ve onun *hashlenmemiş* parolasını bekler. Hashleyip kullanıcıyı oluşturur
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated) // eğer kullanıcı login olduğu halde login sayfasına yönlendiriliyorsa demekki o sayfaya erişim hakkı yoktur
            {
                return View("~/Views/RoleAdmin/Error.cshtml", new string[] { "Erişim hakkınız yok" });
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginAccountViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                var user = _userManager.Find(model.Username, model.Password); // userManager içerisinde gelen bilgiler doğrultusunda kullanıcı arıyoruz
                if (user == null) // kullanıcı yoksa
                {
                    ModelState.AddModelError("", "Yanlış kullanıcı adı veya parola");
                }
                else
                {
                    var authManager = HttpContext.GetOwinContext().Authentication; // uygulamada Login veya Logout işlerimizi yapacak nesne
                    var identity = _userManager.CreateIdentity(user, "ApplicationCookie"); // bir cookie oluşturuyoruz
                    var authProperties = new AuthenticationProperties()
                    {
                        IsPersistent = true // beni hatırla alanı varsayılan olarak true eşitledik
                    };
                    authManager.SignOut(); // eğer kullanıcı daha önce giriş yapmışsa logout yapıyoruz
                    authManager.SignIn(authProperties, identity); // bizden bir authProperties ve identity bekliyor.
                    return Redirect(string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl); // ReturnUrl varsa oraya yönlendir yoksa ana dizine yönlendir
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        [Authorize]
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication; // authManager oluşturduk
            authManager.SignOut(); // Logout işlemini yaptık
            return RedirectToAction("Index", "Home");
        }

    }
}