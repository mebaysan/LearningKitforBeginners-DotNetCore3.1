using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.MVC.Web.Entities
{
    public class Product
    {
        public int Id { get; set; } // Product tablonun Id'si
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public DateTime AddedTime { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string Image { get; set; }

    }
}