using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.MVC.Web.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; } // örnek olarak 5'nolu kategoriyi seçtiğimizde .Products diyerek onun ürünlerini getirebileceğiz

    }
}