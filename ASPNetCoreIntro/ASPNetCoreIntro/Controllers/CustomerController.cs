using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreIntro.Entities;
using ASPNetCoreIntro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var model = new SaveCustomerViewModel()
            {
                Cities = new List<SelectListItem>
                {
                    new SelectListItem{Text="Ankara",Value="06"}, 
                    new SelectListItem{Text="İstanbul",Value="34"},
                    new SelectListItem{Text="İzmir",Value="35"},
                    // Text -> görünen değer, Value -> seçilince gelecek değer
                }
            };
            return View(model);
        }

        [HttpPost]
        public string SaveCustomer(Customer customer) // parametre alıyoruz
        {

            return "Kaydedildi";
        }
    }
}