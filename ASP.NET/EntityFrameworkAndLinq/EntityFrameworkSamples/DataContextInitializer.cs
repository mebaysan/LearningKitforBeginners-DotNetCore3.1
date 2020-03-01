using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSamples
{
    public class DataContextInitializer : DropCreateDatabaseIfModelChanges<DataContext>  // eğer modellerde bir değişiklik olursa veritabanını drop eder ve yeniden oluşturur (SEED DATA). Ve bu Initializer sınıfımıza hangi "context" tipinde işlem yapacağını belirtmemiz gerek
    {


        protected override void Seed(DataContext context) // Test Ortamında Kullanmak için fake data oluşturuyoruz
        {
            List<Kategori> kategoriler = new List<Kategori>() // Kategori tipinde bir List oluşturduk
            {
                 new Kategori(){ KategoriAdi="Telefon"}, // Listemize Kategori'ler ekledik
                 new Kategori(){ KategoriAdi="Bilgisayar"},
                 new Kategori(){ KategoriAdi="Laptop"},
                 new Kategori(){ KategoriAdi="Beyazeşya"}
            };

            foreach (var item in kategoriler)
            {
                context.Kategoriler.Add(item);  // kategoriler listesi içindeki her Kategori'yi context'in Kategoriler'ine ekledik 
            }

            context.SaveChanges(); // context'te yapılan değişiklikleri kayıt ettik


            List<Urun> urunler = new List<Urun>()
            {
                    new Urun(){ UrunAdi="Telefon Ürünü 1", Fiyat=1000, StokAdeti=100,KategoriId=1},
                    new Urun(){ UrunAdi="Telefon Ürünü 2", Fiyat=2000, StokAdeti=100,KategoriId=1},
                    new Urun(){ UrunAdi="Telefon Ürünü 3", Fiyat=3000, StokAdeti=100,KategoriId=1},
                    new Urun(){ UrunAdi="Telefon Ürünü 4", Fiyat=4000, StokAdeti=20,KategoriId=1},
                    new Urun(){ UrunAdi="Telefon Ürünü 5", Fiyat=5000, StokAdeti=100,KategoriId=1},
                    new Urun(){ UrunAdi="Telefon Ürünü 6", Fiyat=6000, StokAdeti=0,KategoriId=1},
                    new Urun(){ UrunAdi="Telefon Ürünü 7", Fiyat=7000, StokAdeti=100,KategoriId=1},
                    new Urun(){ UrunAdi="Telefon Ürünü 8", Fiyat=8000, StokAdeti=200,KategoriId=1},
                    new Urun(){ UrunAdi="Bilgisayar Ürünü 1", Fiyat=1000, StokAdeti=100,KategoriId=2},
                    new Urun(){ UrunAdi="Bilgisayar Ürünü 2", Fiyat=2000, StokAdeti=100,KategoriId=2},
                    new Urun(){ UrunAdi="Bilgisayar Ürünü 3", Fiyat=3000, StokAdeti=100,KategoriId=2},
                    new Urun(){ UrunAdi="Bilgisayar Ürünü 4", Fiyat=4000, StokAdeti=20,KategoriId=2},
                    new Urun(){ UrunAdi="Bilgisayar Ürünü 5", Fiyat=5000, StokAdeti=100,KategoriId=2},
                    new Urun(){ UrunAdi="Bilgisayar Ürünü 6", Fiyat=6000, StokAdeti=0,KategoriId=2},
                    new Urun(){ UrunAdi="Bilgisayar Ürünü 7", Fiyat=7000, StokAdeti=100,KategoriId=2},
                    new Urun(){ UrunAdi="Bilgisayar Ürünü 8", Fiyat=8000, StokAdeti=200,KategoriId=2},
                    new Urun(){ UrunAdi="Laptop Ürünü 1", Fiyat=1000, StokAdeti=100,KategoriId=3},
                    new Urun(){ UrunAdi="Laptop Ürünü 2", Fiyat=2000, StokAdeti=100,KategoriId=3},
                    new Urun(){ UrunAdi="Laptop Ürünü 3", Fiyat=3000, StokAdeti=100,KategoriId=3},
                    new Urun(){ UrunAdi="Laptop Ürünü 4", Fiyat=4000, StokAdeti=20,KategoriId=3},
                    new Urun(){ UrunAdi="Laptop Ürünü 5", Fiyat=5000, StokAdeti=100,KategoriId=3},
                    new Urun(){ UrunAdi="Laptop Ürünü 6", Fiyat=6000, StokAdeti=0,KategoriId=3},
                    new Urun(){ UrunAdi="Laptop Ürünü 7", Fiyat=7000, StokAdeti=100,KategoriId=3},
                    new Urun(){ UrunAdi="Laptop Ürünü 8", Fiyat=8000, StokAdeti=200,KategoriId=3},
                    new Urun(){ UrunAdi="Beyazeşya Ürünü 1", Fiyat=1000, StokAdeti=100,KategoriId=4},
                    new Urun(){ UrunAdi="Beyazeşya Ürünü 2", Fiyat=2000, StokAdeti=100,KategoriId=4},
                    new Urun(){ UrunAdi="Beyazeşya Ürünü 3", Fiyat=3000, StokAdeti=100,KategoriId=4},
                    new Urun(){ UrunAdi="Beyazeşya Ürünü 4", Fiyat=4000, StokAdeti=20,KategoriId=4},
                    new Urun(){ UrunAdi="Beyazeşya Ürünü 5", Fiyat=5000, StokAdeti=100,KategoriId=4},
                    new Urun(){ UrunAdi="Beyazeşya Ürünü 6", Fiyat=6000, StokAdeti=0,KategoriId=4},
                    new Urun(){ UrunAdi="Beyazeşya Ürünü 7", Fiyat=7000, StokAdeti=100,KategoriId=4},
                    new Urun(){ UrunAdi="Beyazeşya Ürünü 8", Fiyat=8000, StokAdeti=200,KategoriId=4},

            };

            foreach (var item in urunler)
            {
                context.Urunler.Add(item);
            }
            context.SaveChanges();




            base.Seed(context); // miras aldığımız sınıf içerisindeki Seed methodunu çalıştırıyoruz(base)
        }
    }
}
