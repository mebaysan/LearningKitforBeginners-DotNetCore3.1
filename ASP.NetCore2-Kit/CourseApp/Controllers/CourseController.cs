using System.Linq;
using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers {
    public class CourseController : Controller // Controller olabilmesi için :Controller yapmalıyız
    {
        public IActionResult Index () {
            return View ();
        }

        [HttpGet]
        public IActionResult Apply () {

            return View ();
        }

        [HttpPost]
        public IActionResult Apply (Student student) { // bu acion'a ait view'daki post edilen formdan alacak. Bu işleme Model Binding denir
            if (ModelState.IsValid) {
                Repository.AddStudent (student); // Post edilirse gelen student değerini Repositor.add diyerek virtual database'imize ekliyoruz.
                return View ("Thanks", student); // Post olursa Thanks adlı view'a gönderiyoruz ve student değerini view'a model olarak yolluyoruz

            }else{
                return View(student);
            }
        }

        public IActionResult Details () {
            var course = new Course ();
            course.Name = "Core MVC";
            course.Description = "Core MVC ders notları";
            course.IsPublished = true;
            return View ("MyDetails", course);
            // istediğimiz bir view sayfasını da gönderebiliriz ve burdan view'a veri (course) gönderdik
        }
        public IActionResult List () {
            var students = Repository.Students.Where (i => i.Confirm == true);
            return View (students);
        }
    }
}