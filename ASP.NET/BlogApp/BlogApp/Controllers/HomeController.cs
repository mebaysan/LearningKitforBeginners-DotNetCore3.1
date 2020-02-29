using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {
        private DataContext context = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var blogs = context.Blogs
                .Where(i => i.IsPublish == true && i.IsInHomePage == true)
                .Select(i => new HomeIndexViewModel()
                {
                    Id = i.Id,
                    Title = i.Title.Length > 100 ? i.Title.Substring(0, 100) + "..." : i.Title, // Lambda yazdık. 100 karakterden büyükse (? sol tarafı şart) ilk 100 karakteri al (? ile : arası) eğer koşul sağlanmıyorsa direk başlığı al (: sağ tarafı)
                    AddedDate = i.AddedDate,
                    IsPublish = i.IsPublish,
                    IsInHomePage = i.IsInHomePage,
                    Description = i.Description,
                    ImagePath = i.ImagePath
                });

            return View(blogs.ToList());
        }
    }
}