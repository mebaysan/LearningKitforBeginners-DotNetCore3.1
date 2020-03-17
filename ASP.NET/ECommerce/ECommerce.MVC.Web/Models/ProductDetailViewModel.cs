using ECommerce.MVC.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.MVC.Web.Models
{
    public class ProductDetailViewModel
    {
        public Product Prod { get; set; }
        public List<Product> RelatedProducts { get; set; }
    }
}