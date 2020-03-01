using EntityFrameworkSamples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Updating
    {
        public void UpdatingIslemleri()
        {
            DataContext context = new DataContext();
            var kategori = context.Kategoriler.Where(i => i.Id == 1).FirstOrDefault(); // bize 1 idli kategoriyi döndürecek eğer yoksa null gelecek
            if (kategori != null) // eğer kategori null değil ise
            {
                kategori.KategoriAdi = "Telefonlar"; // kategorinin adını set ettik
                context.SaveChanges(); // context üzerindeki değişiklikleri kayıt ettik
            }




            Console.ReadLine();
        }
    }
}
