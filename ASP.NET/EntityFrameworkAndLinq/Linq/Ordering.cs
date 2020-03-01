using EntityFrameworkSamples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Ordering
    {
        public void OrderingIslemleri()
        {
            DataContext context = new DataContext();

            var urunler = context.Urunler.OrderBy(i => new { i.Fiyat, i.UrunAdi }).ToList(); // OrderBy -> varsayılan olarak artan bir sıralama yapar. A'dan Z'ye veya 0'dan 100'e, küçükten büyüğe. 2 parametre verirsek önce fiyata göre sıralar sonra fiyatı aynı olanları da ada göre sıralar
            var urunler2 = context.Urunler.OrderByDescending(i => i.Fiyat).Take(5).ToList(); // OrderByDescending -> varsayılan olarak azalan bir sıralama yapar. Z'den A'ya veya 100'den 0'a, büyükten küçüğe. Take(z) -> sadece aldığı parametre kadar veriyi alır. Listelenenler içerisinde en baştaki 5 veri.

            Console.ReadLine();
        }
    }
}
