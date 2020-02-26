using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNetCoreIntro.Entities;
using ASPNetCoreIntro.Models;

namespace ASPNetCoreIntro.Controllers
{
    public class ProductController : Controller // Controller Class'ından inherit edilir
    {
        public IActionResult Index() // Index aksiyonu, Product controller'daki Index aksiyonu diye yorumlanır -> localhost/product/index
        {
            return View(); // Views -> ControllerName -> ActionName view'ı döndürür otomatik olarak
        }

        public string Parametreli(int id) // parametre alıyoruz
        {
            return id.ToString();

        }

        
    }
}