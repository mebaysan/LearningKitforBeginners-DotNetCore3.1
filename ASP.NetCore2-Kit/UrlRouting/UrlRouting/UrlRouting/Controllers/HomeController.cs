using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlRouting.Models;

namespace UrlRouting.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("MyView", new Result()
            {
                Controller = "HomeController",
                Action = "Index"
            });
        }
    }
}