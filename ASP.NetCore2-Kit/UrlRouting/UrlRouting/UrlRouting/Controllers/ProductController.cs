using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlRouting.Models;

namespace UrlRouting.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View("MyView", new Result()
            {
                Controller = "ProductController",
                Action = "Index"
            });
        }
        public IActionResult List()
        {
            return View("MyView", new Result()
            {
                Controller = "ProductController",
                Action = "List"
            });
        }
        public IActionResult Newest()
        {
            return View("MyView", new Result()
            {
                Controller = "ProductController",
                Action = "Newest"
            });
        }
        public IActionResult Details()
        {
            var result = new Result()
            {
                Controller = "ProductController",
                Action = "Details"
            };
            result.RouteData["Id"] = RouteData.Values["id"]; // route yazarken parametreli route kısmında yazdığımız sonunda 'id' olduğu için burada da route'dan otomatik olarak id'yi çekecek.
            result.RouteData["extraparams"] = RouteData.Values["extraparams"];
            return View("MyView", result);
        }
    }
}