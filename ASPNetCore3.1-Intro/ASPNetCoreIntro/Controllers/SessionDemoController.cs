using ASPNetCoreIntro.Entities;
using ASPNetCoreIntro.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreIntro.Controllers
{
    public class SessionDemoController : Controller
    {
        public string Index()
        {

            HttpContext.Session.SetString("isim", "Baysan"); // SetString -> AspNetCore.Http içerisindedir. yapısı "key:value" şeklindedir

            Customer customer = new Customer { Id = 1, FirstName = "Enes", LastName = "Baysan", City = "İstanbul" };
            HttpContext.Session.SetObject("musteri", customer);
            return "Session Oluştu";
        }
        public string Index2()
        {
            //return string.Format("Merhaba {0}", HttpContext.Session.GetString("isim")); // key ile değere ulaşırız

            var customer = HttpContext.Session.GetObject<Customer>("musteri");
            return customer.FirstName;
        }
    }
}
