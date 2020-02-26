using System;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers {
    public class HomeController : Controller {
        public IActionResult Index () {
            // Views/Home/Index.cshtml -> Views altında ilgili controller adındaki dosya altına ilgili Action adındaki cshtml gelir
            int saat = DateTime.Now.Hour; // saat değişkenini oluşturduk
            ViewBag.Greeting = saat > 12 ? "İyi günler" : "Günaydın";
            ViewBag.UserName = "Baysan";
            return View ();
        }
        public IActionResult About () {
            return View ();
        }
    }
}