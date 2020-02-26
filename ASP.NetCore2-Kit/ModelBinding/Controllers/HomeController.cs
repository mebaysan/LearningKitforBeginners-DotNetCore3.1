using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        public HomeController(IRepository _repository)
        {
            repository = _repository;
        }
        public IActionResult Index(int id)
        {
            return View(repository.Get(id));
        }

    }
}
