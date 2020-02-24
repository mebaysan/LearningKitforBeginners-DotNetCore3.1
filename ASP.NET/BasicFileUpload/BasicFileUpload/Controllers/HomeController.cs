using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicFileUpload.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet] // default olarak HttpGet'tir
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(HttpPostedFileBase dosya)
        {
            if (dosya != null && dosya.ContentLength > 0) // eğer dosya değişkeni 0 byte'dan büyükse demekki dosya vardır
            {
                var dosyaUzanti = Path.GetExtension(dosya.FileName); // dosya uzantısını alır
                if (dosyaUzanti == ".jpg" || dosyaUzanti == ".png" || dosyaUzanti == ".pdf") // eğer uzantı istediğimiz şekilde ise
                {
                    var folder = Server.MapPath("~/Uploads"); // projenin anadizini ile Uploads klasörünün yolunu birleştirir
                    var randomDosyaAdi = Path.GetRandomFileName(); // rastgele bir isim verir
                    var dosyaAdi = Path.ChangeExtension(randomDosyaAdi, dosyaUzanti); // ilk parametre dosyanın adı, ikinci parametre dosyanın uzantısı
                    var uploadPath = Path.Combine(folder, dosyaAdi); // folder altına dosyaadi gelecek şekilde bir path verir
                    //var dosyaAdi = Path.GetFileName(dosya.FileName); // System.IO içerisindeki Path class'ı sayesinde controller'dan gelen dosyanın adını aldık
                    //var uploadPath = Path.Combine(Server.MapPath("~/Uploads"), dosyaAdi); // Projenin tam yolunu alıyor ve içerisindeki Uploads klasörü ile birleştiriyor (dosyaAdi'ni ekliyor)
                    dosya.SaveAs(uploadPath); // gelen dosya değişkenini uploadPath yoluna kaydediyoruz
                }
                else
                {
                    ViewData["uyari"] = "Lütfen sadece png veya jpg veya pdf formatında dosya yükleyin";

                }

            }
            else
            {
                ViewData["uyari"] = "Bir Dosya Seçiniz";
            }
            return View();
        }
    }
}