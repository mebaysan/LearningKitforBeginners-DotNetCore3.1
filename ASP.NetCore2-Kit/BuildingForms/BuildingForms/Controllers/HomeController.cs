using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingForms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BuildingForms.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(ProductRepository.Products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(new List<String>() { "Telefon", "Tablet", "Laptop" });
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product) // model binding aracılığı ile product nesnesinin özellikleri direk formdan gelen data ile eşitlendi. Burada kolaylık asp-for="Name" vs.. gibi tag helper'ları kullanmamız sayesinde. Product product yerine -> string Name, string Description, decimal Price, bool isApproved yapabilirdik. Yine otomatik olarak eşitleyecektir.
        {
            // kayıt işlemi
            ProductRepository.Products.Add(product);
            return RedirectToAction("Index"); // post edilince Index action methoduna gitsin
        }
        [HttpGet]
        public IActionResult Search(string q)
        {
            // gelen q değeri ile 
            if (string.IsNullOrWhiteSpace(q)) // eğer q null veya boşluk değere eşitse
            {
                return View();
            }
            else
            {
                return View("Index", ProductRepository.Products.Where(i => i.Name.Contains(q))); // eğer içi noş değilse (q) Index view'a git(Index action üzerinden DEĞİL!) ve içeri yine bir IEnumerable model yolla fakat bu model içerisinde(Contains) 'q' değerini içeren productları model olarak yolla.
            }



        }
    }
}