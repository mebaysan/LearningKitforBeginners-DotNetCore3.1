using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreIntro.Entities;
using ASPNetCoreIntro.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreIntro.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer{Id=1,FirstName="Enes",LastName="Baysan",City="İstanbul"},
                new Customer{Id=2,FirstName="Yusuf",LastName="Baysan",City="İstanbul"},
                new Customer{Id=3,FirstName="Yavuz",LastName="Baysan",City="İstanbul"}
            };
            List<string> shops = new List<string> { "İstanbul", "Ankara", "Hatay" };
            // bir view'a yalnızca bir model gönderilebilir
            var model = new CustomerListViewModel // encapsulation
            {
                Customers = customers,
                Shops = shops

            };
            return View(model);
        }

        [HttpGet] // işaretlemezsek default olarak HttpGet'tir.
        public IActionResult SaveCustomer()
        {
            return View(new SaveCustomerViewModel());
        }

        [HttpPost]
        public string SaveCustomer(Customer customer) // parametre alıyoruz
        {

            return "Kaydedildi";
        }
    }
}