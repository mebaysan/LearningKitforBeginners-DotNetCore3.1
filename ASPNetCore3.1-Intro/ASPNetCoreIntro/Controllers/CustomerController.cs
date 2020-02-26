using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreIntro.Entities;
using ASPNetCoreIntro.Models;
using ASPNetCoreIntro.Services.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNetCoreIntro.Controllers
{
    // bir controller'a attribute routing eklersek bütün aksiyonları attribute routing yapmalıyız. Kısaca: "attribute routing > conventional routing"
    [Route("customer")] // klasik isimlendirme -> controller adı
    public class CustomerController : Controller
    {

        private ILogger _logger; // class'ın fieldı
        public CustomerController(ILogger logger) // constructor
        {
            _logger = logger;
        }

        [Route("index")] // domain.com/customer/index
        [Route("")] // domain.com/customer/  -> yani action ismi belirtilmese de bu action çalışsın
        [Route("~/anasayfa")] // domain.com/anasayfa  -> bu şekilde url gelirse bu aksiyon çalışacak. Ön ek (controller name) önemsizleşir.
        public IActionResult Index()
        {
            _logger.Log("");
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
        [Route("save")] // domain.com/customer/save  -> Request == Get
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
        [Route("save")] // domain.com/customer/save  -> Request == Post
        public string SaveCustomer(Customer customer) // parametre alıyoruz
        {

            return "Kaydedildi";
        }
    }
}