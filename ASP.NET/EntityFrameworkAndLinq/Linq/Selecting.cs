using EntityFrameworkSamples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Selecting
    {
        public void SelectIslemleri()
        {
            DataContext context = new DataContext();
            var urunler = context.Urunler
                .Select(i => new
                {
                    // Select ile context.Urunler içerisindeki her bir objeyi döneceğiz ve bir obje  oluşturacağız (bu tip objelere "anonymous object" denir)
                    ProductName = i.UrunAdi.Length > 9 ? i.UrunAdi.Substring(0, 6) + "..." : i.UrunAdi, // Ternary Expression -> koşul ? if : else; -- Eğer ürün adı 8 karakterden fazla ise (? sol tarafı) ürün adının ilk 6 karakterini al ve sonuna üç nokta ekle (? ve : arası) 8 karakterden fazla değil ise ürün adını olduğu gibi ekle (: sağ tarafı)
                    Price = i.Fiyat,
                    Category = i.Kategori.KategoriAdi
                    // oluşturduğumuz yeni anonymous objeye i'nin UrunAdi ve Fiyat proplarını atadık. İstersek de ProductName,Price gibi anonymous proplar oluşturabiliriz
                })
                .ToList(); // anonymous objeleri liste haline getirdik
            foreach (var item in urunler)
            {
                Console.WriteLine("Ürün Adı: {0}\t\tFiyat: {1} Tl\t\tKategori: {2}", item.ProductName, item.Price, item.Category);
            }
            Console.WriteLine("-------------------");
            var kategoriler = context.Kategoriler
                .Select(i => new
                {
                    CategoryName = i.KategoriAdi,
                    ProductCount = i.Urunler.Count(),
                    Products = i.Urunler.Select(u => new
                    {
                        ProductName = u.UrunAdi,
                        Price = u.Fiyat
                    }).ToList() // bu da anonymous bir list döndürür
                })
                .ToList();
            foreach (var kategori in kategoriler)
            {
                Console.WriteLine("Kategori Adı: {0}\t\t\tÜrün Adedi: {1}", kategori.CategoryName, kategori.ProductCount);
                foreach (var product in kategori.Products) // döndüğümüz her kategorinin ürünlerini de dönüyoruz
                {
                    Console.WriteLine("\tÜrün Adı: {0}\t\tFiyat: {1}", product.ProductName, product.Price);
                }
            }
            Console.ReadLine();

        }
    }
}
