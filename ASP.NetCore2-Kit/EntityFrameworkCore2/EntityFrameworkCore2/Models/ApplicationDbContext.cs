using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } // veritabanında bir tablo oluşturmuş olduk.
        // DbSet generic'tir.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) // constructor.
            // .net core 2'den önce entity paketleri nuget ile yüklenirdi fakat artık direkt geliyor ve connectionstring falanı web confige yazarken arrtık appsettings.json dosyasına yazıyoruz.
        {

        }
    }
}
