using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoreMVCFundamentals.Models;
using CoreMVCFundamentals.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCFundamentals.Controllers {
    public class HomeController : Controller {
        public IActionResult Index () {
            // return Content("content döner"); -> parametre olarak aldığı stringi döndürür
            // return NotFound(); -> 404 durum kodu döndürür
            // return new EmptyResult(); -> boş sayfa(değer) döndürür
            // return RedirectToAction("Privacy"); -> parametre olarak aldığı action'a redirect(yönlendirme) yapar
            // return RedirectToAction("Privacy","About"); -> About controller altındaki Privacy action'a gider
            // return RedirectToAction("Privacy","About", new{id=5,sortBy="name"}); -> query string ile gidecek
            return View ();
        }
        public IActionResult Details (int id) {
            return Content ("id = " + id);
        }

        public IActionResult Privacy () {
            return View ();
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ByReleased (int year, int month) {
            return Content ("year : " + year + " month : " + month);
        }
        public IActionResult ViwData () {
            var kurs = new Course () { Id = 1, Name = "Komple uygulamalı web geliştirme" };
            ViewData["course"] = kurs; // View'a veri gönderiyoruz. course -> keyword olmuş oldu
            ViewBag.course = kurs;

            var viewresult = new ViewResult ();
            // viewresult.ViewData.Model = return View (kurs)

            return View (kurs); // sayfaya viewbag veya viewdata yerine direk model olarak yollayabiliriz

        }
        public IActionResult CStudents () {
            var kurs = new Course () { Id = 1, Name = "Komple uygulamalı web geliştirme" };
            var students = new List<Student> () {
                new Student () { Name = "Baysan" },
                new Student () { Name = "Enes" },
                new Student () { Name = "Yusuf" }
            };
            var viewModel = new CourseStudentViewModel ();
            viewModel.Course = kurs;
            viewModel.Students = students;
            // View'a iki model birden göndermek zor olduğu için iki modeli yeni bir modelde birleştirip gönderdik
            return View (viewModel);
        }
        public IActionResult Layout(){
            
            return View();
        }
    }
}