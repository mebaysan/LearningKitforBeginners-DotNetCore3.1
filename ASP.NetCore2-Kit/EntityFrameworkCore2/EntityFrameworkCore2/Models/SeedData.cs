using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore2.Models
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product() { Name="Product1",Description="Product1 Description",Price=1000,Category="Category1"},
                    new Product() { Name = "Product2", Description = "Product2 Description", Price = 2000, Category = "Category1" },
                    new Product() { Name = "Product3", Description = "Product3 Description", Price = 3000, Category = "Category1" },
                    new Product() { Name = "Product4", Description = "Product4 Description", Price = 4000, Category = "Category1" },
                    new Product() { Name = "Product5", Description = "Product5 Description", Price = 5000, Category = "Category1" }
                    );
                context.SaveChanges();
            }
        }
    }
}
