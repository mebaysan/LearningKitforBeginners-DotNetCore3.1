using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxFileUpload.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet] // default olarak HttpGet'tir
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(HttpPostedFileBase[] dosyalar)
        {
            for (int i = 0; i < dosyalar.Length; i++)
            {
                var dosyaUzanti = Path.GetExtension(dosyalar[i].FileName); // dosya uzantısını alır
                var folder = Server.MapPath("~/Uploads"); // projenin anadizini ile Uploads klasörünün yolunu birleştirir
                var randomDosyaAdi = Path.GetRandomFileName(); // rastgele bir isim verir
                var dosyaAdi = Path.ChangeExtension(randomDosyaAdi, dosyaUzanti); // ilk parametre dosyanın adı, ikinci parametre dosyanın uzantısı
                var uploadPath = Path.Combine(folder, dosyaAdi); // folder altına dosyaadi gelecek şekilde bir path verir
                dosyalar[i].SaveAs(uploadPath); // gelen dosya değişkenini uploadPath yoluna kaydediyoruz
            }

            return Json("");
        }
    }
}
