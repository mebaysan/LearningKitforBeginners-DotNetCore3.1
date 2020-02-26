using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBlogRepository blogRepository;
        public HomeController(IBlogRepository repository)
        {
            blogRepository = repository;
        }
        public IActionResult Index()
        {
            var model = new HomeBlogModel();
            model.HomeBlogs = blogRepository.GetAll().Where(p => p.isApproved == true && p.isHome == true).ToList();
            model.SliderBlogs = blogRepository.GetAll().Where(p => p.isApproved == true && p.isSlider == true).ToList();
            return View(model);
        }
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
    }
}