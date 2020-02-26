using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository repositoryCategory;
        public CategoryController(ICategoryRepository _repositoryCategory)
        {
            repositoryCategory = _repositoryCategory;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(repositoryCategory.GetAll());
        }
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category entity)
        {
            if (ModelState.IsValid)
            {
                repositoryCategory.AddCategory(entity);
                return RedirectToAction("List");
            }
            return View(entity);
        }
    }
}