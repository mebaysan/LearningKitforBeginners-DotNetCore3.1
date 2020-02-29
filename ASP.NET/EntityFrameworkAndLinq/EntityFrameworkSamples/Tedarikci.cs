using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSamples
{
    public class Tedarikci
    {
        public int Id { get; set; }
        public string FirmaAdi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }

        public List<Urun> Urunler { get; set; }
    }
}
