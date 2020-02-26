using BlogApp.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        //                  BURASI FAKE DATABASE ITEM'LARININ YERİDİR. 
        public static void Seed(IApplicationBuilder app)
        {
            BlogContext context = app.ApplicationServices.GetRequiredService<BlogContext>(); // Uygulama içerisindeki context'e ulaştık.
            context.Database.Migrate();
            if (!context.Categories.Any()) // eğer context'in Categories kısmı boş ise otomatik burdaki nesneler ile doldur
            {
                context.Categories.AddRange(
                    new Category() {Name="Kategori 1" },
                    new Category() { Name = "Kategori 2" },
                    new Category() { Name = "Kategori 3" }
                    );
                context.SaveChanges();
            }
            if (!context.Blogs.Any()) // eğer context'in Blogs tablosu boş ise otomatik burdaki nesneler ile doldur
            {
                context.Blogs.AddRange(
                    new Blog() { Title = "Deneme 1", Description = "Deneme 1 açıklaması 1", Body = "Deneme 1 Body", Image = "resimCard.jpg", Date = DateTime.Now.AddDays(-5), isApproved = true, CategoryId = 1 },
                    new Blog() { Title = "Deneme 2", Description = "Deneme 2 açıklaması 2", Body = "Deneme 2 Body", Image = "resimCard2.jpg", Date = DateTime.Now.AddDays(-7), isApproved = true, CategoryId = 1 },
                    new Blog() { Title = "Deneme 3", Description = "Deneme 3 açıklaması 3", Body = "Deneme 3 Body", Image = "resimCard3.jpg", Date = DateTime.Now.AddDays(-6), isApproved = false, CategoryId = 2 },
                    new Blog() { Title = "Deneme 4", Description = "Deneme 4 açıklaması 4", Body = "Deneme 4 Body", Image = "resimCard4.jpg", Date = DateTime.Now.AddDays(-9), isApproved = true, CategoryId = 3 }
                    );
                context.SaveChanges();
            }
        }
    }
}
