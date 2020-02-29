using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogApp.Models;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Blog
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.Category)
                .OrderByDescending(i => i.AddedDate); // Include -> her blog'un kategorisini de al (map)
            return View(blogs.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            // bütün kategorileri alır. Id'sini value Name'ini key olarak alır
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Content,Description,ImagePath,CategoryId")] Blog blog)
        {
            blog.AddedDate = DateTime.Now;
            blog.IsInHomePage = false;
            blog.IsPublish = false;
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", blog.CategoryId);
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,Description,IsPublish,IsInHomePage,ImagePath,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(blog).State = EntityState.Modified;
                var entity = db.Blogs.Find(blog.Id);
                if (entity != null)
                {
                    entity.Title = blog.Title;
                    entity.Description = blog.Description;
                    entity.Content = blog.Content;
                    entity.IsInHomePage = blog.IsInHomePage;
                    entity.IsPublish = blog.IsPublish;
                    entity.ImagePath = blog.ImagePath;
                    entity.CategoryId = blog.CategoryId;
                    db.SaveChanges();
                    TempData["Blog"] = entity;
                    return RedirectToAction("Index");
                }

            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult List(int? id, string search_query)
        {
            var blogs = db.Blogs
                .Where(i => i.IsPublish == true)
                .Select(i => new HomeIndexViewModel()
                {
                    Id = i.Id,
                    Title = i.Title.Length > 100 ? i.Title.Substring(0, 100) + "..." : i.Title, // Lambda yazdık. 100 karakterden büyükse (? sol tarafı şart) ilk 100 karakteri al (? ile : arası) eğer koşul sağlanmıyorsa direk başlığı al (: sağ tarafı)
                    AddedDate = i.AddedDate,
                    IsPublish = i.IsPublish,
                    IsInHomePage = i.IsInHomePage,
                    Description = i.Description,
                    ImagePath = i.ImagePath,
                    CategoryId = i.CategoryId
                }).AsQueryable();
            // AsQueryable -> bu sorguya extra where'leri ekleyebiliriz.
            if (string.IsNullOrEmpty("search_query") == false) // eğer boş veya null değil ise
            {
                blogs = blogs.Where(i => i.Title.Contains(search_query) || i.Description.Contains(search_query));
            }
            if (id != null)
            {
                blogs = blogs.Where(i => i.CategoryId == id);
            }
            return View(blogs.ToList());
        }
    }
}
