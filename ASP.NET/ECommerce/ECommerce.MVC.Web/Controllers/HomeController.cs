using ECommerce.MVC.Web.Entities;
using ECommerce.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.MVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _context = new DataContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View(_context.Products.Where(i => i.IsApproved == true && i.IsHome == true).OrderBy(x => x.AddedTime).Take(3).ToList());
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            Product prod = _context.Products.Where(i => i.Id == id).FirstOrDefault();
            ProductDetailViewModel model = new ProductDetailViewModel()
            {
                Prod = prod,
                RelatedProducts = _context.Products
                .Where(i => i.CategoryId == prod.CategoryId && i.Id != prod.Id)
                .Take(4)
                .ToList()
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult List(int? id, string? q)
        {
            List<Product> products = new List<Product>();
            if (id != null)
            {
                products = _context.Products.Where(i => i.IsApproved == true && i.CategoryId == id).ToList();
            }
            else if (q != null)
            {
                products = _context.Products.Where(i => i.IsApproved == true && i.Name.Contains(q)).ToList();
            }
            else
            {
                products = _context.Products.Where(i => i.IsApproved == true).ToList();
            }
            List<Category> categories = _context.Categories.ToList();
            ProductListViewModel model = new ProductListViewModel()
            {
                Products = products,
                Categories = categories
            };
            return View(model);
        }
    }
}