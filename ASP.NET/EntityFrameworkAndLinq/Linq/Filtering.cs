using EntityFrameworkSamples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Filtering
    {
        public void FilterIslemleri()
        {
            DataContext context = new DataContext();
            var urun = context.Urunler.Where(i => i.Id == 1).FirstOrDefault(); // tek bir kayıt geleceğinden emin isek FirstOrDefault kullanabiliriz
            var urunler = context.Urunler
                .Where(i => i.KategoriId == 1 || i.KategoriId == 2) // KategoriId'si 1 olan tüm ürünleri getir ve listeye dök
                .ToList();

            foreach (var entity in urunler)
            {
                Console.WriteLine("Ürün Adı: {0}", entity.UrunAdi);
            }

            Console.WriteLine("-------------------------------");


            var urunListesi = context.Kategoriler // burada Kategoriler tablosu üzerinden filtreleme yapıyoruz
                .Where(i => i.KategoriAdi == "Telefon")
                .SelectMany(i => i.Urunler) // Sadece Select kullanırsak dönen değerlerin tipi Kategori olacak. Fakat; SelectMany kullandığımız için dönen değerlerin tipi Urun olmakta. Çünkü burada Kategori nesnesinin List<Urun> nesnesini sorguluyoruz
                .ToList();
            foreach (var item in urunListesi)
            {
                Console.WriteLine("Ürün Adı: {0}", item.UrunAdi);

            }

            Console.WriteLine("--------------");

            var productList = context.Kategoriler
                .Where(i => i.KategoriAdi == "Telefon" || i.KategoriAdi == "Bilgisayar") // KategoriAdi Telefon veya Bilgisayar olanları filtrele
                .Select(i => new
                {
                    KategoriAdi = i.KategoriAdi, // anonymous bir object oluştur ve KategoriAdi propu set et
                    UrunListesi = i.Urunler // anon object'in UrunListesi propunu set et fakat;
                    .Where(a => a.Fiyat <= 3000) // set ederken yukardan gelen ürünler içerisinden fiyatı 3000'den küçük olanları filtrele
                    .Select(b => new
                    {
                        UrunAdi = b.UrunAdi, // filtrelediklerini de bir anon object olarak oluştur ve yukardaki anon object'in UrunListesi prop'una set et
                        Fiyat = b.Fiyat
                    })
                    .ToList()
                    .OrderByDescending(c => c.Fiyat) // Fiyat'a göre azalan (büyükten küçüğe) sıralama yaptık
                })
                .ToList();
            foreach (var cat in productList)
            {
                Console.WriteLine("Filtrelenmiş Kategori Adı = {0}\t\tÜrün Adedi = {1}", cat.KategoriAdi, cat.UrunListesi.Count());
                foreach (var prod in cat.UrunListesi)
                {
                    Console.WriteLine("\t\tÜrün Adı = {0}\tFiyatı = {1}", prod.UrunAdi, prod.Fiyat);
                }

            }
            Console.ReadLine();
        }
    }
}
