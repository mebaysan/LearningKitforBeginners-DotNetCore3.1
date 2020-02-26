using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore2.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>()
        {
            new Product(){ProductId=1,Name="Product 1",Price=1000,Category="Category1",Description="It is a nice product1!"},
            new Product(){ProductId=1,Name="Product 2",Price=2000,Category="Category1",Description="It is a nice product2!"},
            new Product(){ProductId=1,Name="Product 3",Price=3000,Category="Category1",Description="It is a nice product3!"},
            new Product(){ProductId=1,Name="Product 4",Price=4000,Category="Category1",Description="It is a nice product4!"}
        }.AsQueryable(); // asqueryable ile geriye gönderdik
    }
}
