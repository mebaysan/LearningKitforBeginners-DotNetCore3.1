using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSamples
{
    public class Urun
    {
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public double Fiyat { get; set; }
        public int StokAdeti { get; set; }

        public int KategoriId { get; set; }


        // burası  program anında kullanılacak
        public Kategori Kategori { get; set; }

        public List<Tedarikci> Tedarikciler { get; set; }
    }
}
