using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECommerce.MVC.Web.Entities
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext> // Eğer Veritabanı modelleri değişirse sil baştan oluştur
    {
        protected override void Seed(DataContext context) // database'i seedliyoruz (besliyoruz) 
        {
            List<Category> categories = new List<Category>()
            {
                new Category(){Name="Yağlar",Description="Sağlıklı Yağlar"},
                new Category(){Name="Bebek Ürünleri",Description="Bebek Bakım Ürünleri"},
                new Category(){Name="Bakım Ürünleri",Description="Kişisel Bakım Ürünleri"},
                new Category(){Name="Evcil Hayvan Ürünleri",Description="Evcil Hayvan Bakım Ürünleri"},

            };
            foreach (var cat in categories)
            {
                context.Categories.Add(cat);
            }
            context.SaveChanges();
            List<Product> products = new List<Product>()
            {
                new Product(){Name="Papatya Yağı",Description="Sağlıklı bir yağ",Price=15.99,IsApproved=false,IsHome=false,Stock=100,CategoryId=1,AddedTime=DateTime.Now,Image="1.png"},
                new Product(){Name="Çörekotu Yağı",Description="Sağlıklı bir yağ",Price=39.99,IsApproved=true,IsHome=false,Stock=67,CategoryId=1,AddedTime=DateTime.Now.AddDays(-7),Image="1.png"},
                new Product(){Name="Argan Yağı",Description="Sağlıklı bir yağ",Price=89.99,IsApproved=true,IsHome=false,Stock=35,CategoryId=1,AddedTime=DateTime.Now,Image="1.png"},

                new Product(){Name="Cici Bebe",Description="Bebe Bisküvisi",Price=12.35,IsApproved=true,IsHome=false,Stock=245,CategoryId=2,AddedTime=DateTime.Now,Image="1.png"},
                new Product(){Name= "Bebek Bezi",Description="Bebe Bezi faydalıdır",Price=35.75,IsApproved=true,IsHome=false,Stock=100,CategoryId=2,AddedTime=DateTime.Now.AddDays(-7),Image="1.png"},
                new Product(){Name="Bebek Kutu Mama",Description="Bebek Kutu Mama",Price=6.75,IsApproved=true,IsHome=false,Stock=45,CategoryId=2,AddedTime=DateTime.Now.AddDays(-7),Image="1.png"},

                new Product(){Name="Dezenfektan",Description="Korona virüsüne iyi gelir",Price=45.00,IsApproved=true,IsHome=true,Stock=55,CategoryId=3,AddedTime=DateTime.Now,Image="1.png"},
                new Product(){Name="Kolonya",Description="Kolonya virüs öldürür",Price=75.00,IsApproved=true,IsHome=true,Stock=15,CategoryId=3,AddedTime=DateTime.Now,Image="1.png"},
                new Product(){Name="Hasta Maskesi",Description="Hasta maskesi koronadan korur",Price=5.99,IsApproved=true,IsHome=true,Stock=0,CategoryId=3,AddedTime=DateTime.Now,Image="1.png"},
                new Product(){Name="Saf Alkol",Description="Saf Alkol kolonya yapımında kullanılabilir",Price=75.50,IsApproved=true,IsHome=true,Stock=100,CategoryId=3,AddedTime=DateTime.Now,Image="1.png"},
            };
            foreach (var prod in products)
            {
                context.Products.Add(prod);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}