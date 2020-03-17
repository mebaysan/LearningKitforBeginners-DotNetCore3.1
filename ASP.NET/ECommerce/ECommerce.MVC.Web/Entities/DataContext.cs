using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECommerce.MVC.Web.Entities
{
    public class DataContext : DbContext // nuget packages ile entity framework yükledik. DbContext'ten türettik
    {
        public DataContext() : base("veriBaglantisi") // connection stringi veriyoruz (web.config altında)
        {
            Database.SetInitializer(new DataInitializer()); // DataInitializer'ımızı Contexte veriyoruz ve seedlemeyi sağlıyoruz
        }
        public DbSet<Product> Products { get; set; } // Tabloları oluşturduk
        public DbSet<Category> Categories { get; set; }
        /*
         * Entity Framework ile çalışırken
         * -) NuGet ile Entity Framework indir
         * -) Entity Classlarını Belirle
         * -) Data Context Oluştur
         * -) web.config altına connection string oluştur
         * -) DbSet ile tabloları ekle
         * -) DataInitializer ekle
         * -) DataInitializer'ı DropCreateDatabaseIfModelChanges'den türek ve tipini Context'in olarak belirle
         * -) Seed methodunu override et
         * -) Dataları oluştur ve contexte yolla
         * -) DataContext'in içerisinde Database Inıtializer'i belirle
         */
    }
}