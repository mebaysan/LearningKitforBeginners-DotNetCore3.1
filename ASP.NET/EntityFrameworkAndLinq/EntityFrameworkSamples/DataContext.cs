using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSamples
{
    public class DataContext : DbContext
    {
        //public DataContext():base("CustomDatabaseName") // içine connection string veya istediğimiz bir veritabanı adı girebiliriz (opsiyonel)
        public DataContext() : base("urunConnection") // istersek içine connection string verebiliriz (App.config altında)
        {
            Database.SetInitializer(new DataInitializer()); // Veritabanı oluşturulurken hangi Initializer'ı kullanacağını set ettik. Bu sayede ilk Context instance oluştuğunda belirttiğimiz Initializer çalışacak ve Data Seeding gerçekleşecek
        }


        public DbSet<Kategori> Kategoriler { get; set; } // Kategori tipinde datalarla işlem yapacağımız için belirttik. DbSet türünde olmalı(bir nevi list)
        public DbSet<Urun> Urunler { get; set; }
    }
}
