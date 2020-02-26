using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogApp.Models
{
    // EF ile ayarları değiştirmediğimiz için standart isimlendirme db oluşturulacak => NamespaceAdi.ContextAdi -> BlogApp.Models.DataContext (Default)
    public class DataContext : DbContext // DbContext'ten inherit etmeliyiz
    {
        //public DataContext():base("CustomDatabaseName") // içine connection string veya istediğimiz bir veritabanı adı girebiliriz (opsiyonel)
        public DataContext():base("CustomConnectionString") // istersek içine connection string verebiliriz (web.config altında)
        {
            Database.SetInitializer(new DataContextInitializer()); // Veritabanı oluşturulurken hangi Initializer'ı kullanacağını set ettik. Bu sayede ilk Context instance oluştuğunda belirttiğimiz Initializer çalışacak ve Data Seeding gerçekleşecek
        }
        public DbSet<Blog> Blogs { get; set; } // Blog tipinde datalarla işlem yapacağımız için belirttik. DbSet türünde olmalı(bir nevi list)
        public DbSet<Category> Categories { get; set; }
    }
}