using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSamples
{
    class Program
    {
        static void Main(string[] args)
        {

            DataContext db = new DataContext();

            var urunler = db.Urunler.ToList();

            foreach (var item in urunler)
            {
                Console.WriteLine("urun adı : {0}",item.UrunAdi);
            }

            Console.WriteLine("veritabanı oluştu");

            Console.ReadLine();

        }
    }
}
