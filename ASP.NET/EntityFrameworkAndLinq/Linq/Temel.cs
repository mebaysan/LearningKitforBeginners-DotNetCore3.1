using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Temel
    {
        public void Temeller()
        {
            List<int> sayilar = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,10
            };

            var gelenSayilar = sayilar.Select(i => i += 2); // Lambda expression, sayilar.Select dersek; sayilar listesi içindeki her bir elemanı döner ve i yerine atar. Bu örnekte her i elemanını 2 arttırdık
            foreach (var sayi in gelenSayilar)
            {
                Console.WriteLine(sayi);
            }
            Console.WriteLine("-------------");

            var gelenSayilar2 = sayilar.Where(i => i % 2 == 1); // Where filtreleme yapar. Bu örnekte modu 1'e eşit olan sayıları yani tek sayıları getirir
            foreach (var sayi in gelenSayilar2)
            {
                Console.WriteLine(sayi);
            }
            Console.WriteLine("-------------");

            var gelenSayilar3 = sayilar.Where(i => i % 2 == 0).OrderBy(i => i); // Çift sayıları al ve Artan(küçükten büyüğe)(varsayılan) olarak sırala
            foreach (var sayi in gelenSayilar3)
            {
                Console.WriteLine(sayi);
            }
            Console.WriteLine("-------------");


            var gelenSayilar4 = sayilar.Where(i => i % 2 == 0).OrderByDescending(i => i); // Çift sayıları al ve Azalan(büyükten küçüğe) olarak sırala
            foreach (var sayi in gelenSayilar4)
            {
                Console.WriteLine(sayi);
            }
            Console.WriteLine("-------------");


            Console.ReadLine();
        }
    }
}
