using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository repositoryBlog;
        private ICategoryRepository repositoryCategory;
        public BlogController(IBlogRepository _repositoryBlog, ICategoryRepository _repositoryCategory)
        {
            repositoryBlog = _repositoryBlog;
            repositoryCategory = _repositoryCategory;
        }
        public IActionResult Index(int? id, string q) // illa id diye bir parametre gelecek değil
        {
            var query = repositoryBlog.GetAll().Where(p => p.isApproved);
            if (id != null)
            {
                query = query.Where(i => i.CategoryId == id);
            }
            if (!string.IsNullOrEmpty(q))
            {
                //query = query.Where(i => i.Title.Contains(q) || i.Description.Contains(q) || i.Body.Contains(q)); // yolladığımız parametre, i içinde geçiyor mu
                query = query.Where(i => EF.Functions.Like(i.Title, "%" + q + "%") || EF.Functions.Like(i.Description, "%" + q + "%") || EF.Functions.Like(i.Body, "%" + q + "%")); // .Net Core ile gelen özellik
            }
            return View(query.OrderByDescending(i => i.Date));
        }
        public IActionResult List()
        {
            return View(repositoryBlog.GetAll()); // bütün blogları alarak view üzerine gönderiyoruz
        }
        public IActionResult Details(int id)
        {
            return View(repositoryBlog.GetById(id));
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(repositoryCategory.GetAll(), "CategoryId", "Name"); // post edilince gönderilecek alan CategoryId fakat gösterilecek alan Name alanı olacak
            return View(new Blog());
        }
        [HttpPost]
        public IActionResult Create(Blog entity)
        {
            ViewBag.Categories = new SelectList(repositoryCategory.GetAll(), "CategoryId", "Name");
            entity.Date = DateTime.Now; // buraya gelen entity'nin date alanını şuan ki sistem saati ile dolduruyoruz
            if (ModelState.IsValid) // eğer her şey doğru ise
            {
                repositoryBlog.AddBlog(entity); // repository'e entity'i ekle
                return RedirectToAction("List"); // ve List action'a gönder
            }
            return View(entity); // eğer problemli bir şey varsa entity ile birlikte geri döndür
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(repositoryCategory.GetAll(), "CategoryId", "Name");
            return View(repositoryBlog.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Blog entity, IFormFile file) // bir dosya bekliyoruz ve methodu async bir methoda çeviriyoruz ve gönderilen file IFormFile'dan beklenir
        {
            ViewBag.Categories = new SelectList(repositoryCategory.GetAll(), "CategoryId", "Name");
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName); // kaydedilecek yeri bekliyoruz.
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream); // stream oluşturup stream'i path içerisine ekliyoruz
                        entity.Image = file.FileName; // entity'nin Image prop'unu gönderdiğimiz data ile eşitliyoruz
                    }
                }
                repositoryBlog.UpdateBlog(entity);
                TempData["message"] = $"{entity.Title} başarıyla güncellendi";
                return RedirectToAction("List");
            }
            return View(entity);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(repositoryBlog.GetById(id));
        }
        [HttpPost, ActionName("Delete")] // burası önemli! action adını delete verdik fakat aşağıda farklı tanımladık; sebebi ise karışıklık olmasın diye
        public IActionResult DeleteConfirmed(int id)
        {
            repositoryBlog.DeleteBlog(id);
            TempData["message"] = $"{id} numaralı kayıt silindi!";
            return RedirectToAction("List");
        }
    }
}