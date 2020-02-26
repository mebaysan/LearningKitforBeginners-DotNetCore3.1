using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore2.Models
{
    public class Product
    {
        // Burası entity sınıfımız. Database içerisindeki kolonlar buraya göre olacak
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
    }
}
