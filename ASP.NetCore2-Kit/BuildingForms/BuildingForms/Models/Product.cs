using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingForms.Models
{
    public class Product
    {
        public int Id { get; set; }
        public bool isApproved { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
