using EntityFrameworkSamples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Deleting
    {
        public void DeletingIslemleri()
        {
            DataContext context = new DataContext();
            var kategori = context.Kategoriler.Where(i => i.Id == 1).FirstOrDefault();
            if (kategori != null)
            {
                context.Kategoriler.Remove(kategori); // context içerisindeki kategorilerden kategori nesnesini sil. !Önemli!!! -> ilişkisel bir model olduğundan bu silinirse buna ait bütün ürünler de silinir
                context.SaveChanges();
            }


            Console.ReadLine();
        }
    }
}
