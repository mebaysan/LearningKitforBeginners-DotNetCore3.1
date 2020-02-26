using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingForms.Models
{
    public static class ProductRepository
    {
        private static List<Product> _products;
        static ProductRepository()
        {
            _products = new List<Product>()
            {

                new Product() { Id = 1, Name = "Product 1", Description = "Product 1 açıklaması", Price = 10, isApproved = true,Category="Category1" },
                new Product() { Id = 2, Name = "Product 2", Description = "Product 1 açıklaması", Price = 100, isApproved = true,Category="Category2" },
                new Product() { Id = 3, Name = "Product 3", Description = "Product 1 açıklaması", Price = 150, isApproved = false,Category="Category1" },
                new Product() { Id = 4, Name = "Product 4", Description = "Product 1 açıklaması", Price = 230, isApproved = true,Category="Category2" },
                new Product() { Id = 5, Name = "Product 5", Description = "Product 1 açıklaması", Price = 105, isApproved = false,Category="Category1" }

            };
        }
        public static List<Product> Products
        {
            get { return _products; }
        }
        public static void AddProduct(Product entity)
        {
            _products.Add(entity);
        }
    }
}
