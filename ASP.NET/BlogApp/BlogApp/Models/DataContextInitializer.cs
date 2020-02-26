using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogApp.Models
{
    public class DataContextInitializer : DropCreateDatabaseIfModelChanges<DataContext> // eğer modellerde bir değişiklik olursa veritabanını drop eder ve yeniden oluşturur (SEED DATA). Ve bu Initializer sınıfımıza hangi "context" tipinde işlem yapacağını belirtmemiz gerek
    {
        protected override void Seed(DataContext context) // Test Ortamında Kullanmak için fake data oluşturuyoruz
        {
            List<Category> categories = new List<Category>() // Category tipinde bir List oluşturduk
            {
                new Category(){Name="C#"}, // Listemize Category'ler ekledik
                new Category(){Name="Asp.Net MVC5"},
                new Category(){Name="Python"},
                new Category(){Name="Django"},
                new Category(){Name="Asp.Net Core"},
            };
            foreach (var cat in categories)
            {
                context.Categories.Add(cat); // categories listesi içindeki her Category'i context'in Categories'ine ekledik 
            }
            context.SaveChanges(); // contexte yapılan değişiklikleri kayıt ettik

            List<Blog> blogs = new List<Blog>() // Seed Data için fake data oluşturduk
            {
                new Blog(){Title="Django Dersleri",Description="Django Desc",Content="Django Dersleri içeriği",IsInHomePage=true,IsPublish=true,CategoryId=4,ImagePath="django.jpg",AddedDate=DateTime.Now.AddDays(-10)},
                new Blog(){Title="MVC5 Dersleri",Description="MVC5 Desc",Content="MVC5 Dersleri içeriği",IsInHomePage=false,IsPublish=true,CategoryId=2,ImagePath="mvc5.jpg",AddedDate=DateTime.Now.AddDays(-8)},
                new Blog(){Title=".Net Core Dersleri",Description=".Net Core Desc",Content=".Net Core Dersleri içeriği",IsInHomePage=true,IsPublish=true,CategoryId=5,ImagePath="netcore.jpg",AddedDate=DateTime.Now.AddDays(-1)},
                new Blog(){Title="C# Dersleri",Description="C# Desc",Content="C# Dersleri içeriği",IsInHomePage=false,IsPublish=true,CategoryId=1,ImagePath="csharp.jpg",AddedDate=DateTime.Now.AddDays(-10)},
                new Blog(){Title="Python Dersleri",Description="Python Desc",Content="Python Dersleri içeriği",IsInHomePage=true,IsPublish=true,CategoryId=4,ImagePath="django.jpg",AddedDate=DateTime.Now.AddDays(-2)},
                new Blog(){Title="Django Dersleri",Description="Django Desc",Content="Django Dersleri içeriği",IsInHomePage=true,IsPublish=true,CategoryId=4,ImagePath="django.jpg",AddedDate=DateTime.Now.AddDays(-10)},
                new Blog(){Title="MVC5 Dersleri",Description="MVC5 Desc",Content="MVC5 Dersleri içeriği",IsInHomePage=false,IsPublish=true,CategoryId=2,ImagePath="mvc5.jpg",AddedDate=DateTime.Now.AddDays(-8)},
                new Blog(){Title=".Net Core Dersleri",Description=".Net Core Desc",Content=".Net Core Dersleri içeriği",IsInHomePage=true,IsPublish=true,CategoryId=5,ImagePath="netcore.jpg",AddedDate=DateTime.Now.AddDays(-15)},
                new Blog(){Title="C# Dersleri",Description="C# Desc",Content="C# Dersleri içeriği",IsInHomePage=false,IsPublish=true,CategoryId=1,ImagePath="csharp.jpg",AddedDate=DateTime.Now.AddDays(-10)},
                new Blog(){Title="Python Dersleri",Description="Python Desc",Content="Python Dersleri içeriği",IsInHomePage=true,IsPublish=true,CategoryId=4,ImagePath="django.jpg",AddedDate=DateTime.Now.AddDays(-20)},
                new Blog(){Title="Django Dersleri",Description="Django Desc",Content="Django Dersleri içeriği",IsInHomePage=true,IsPublish=true,CategoryId=4,ImagePath="django.jpg",AddedDate=DateTime.Now.AddDays(-12)},
                new Blog(){Title="MVC5 Dersleri",Description="MVC5 Desc",Content="MVC5 Dersleri içeriği",IsInHomePage=false,IsPublish=true,CategoryId=2,ImagePath="mvc5.jpg",AddedDate=DateTime.Now.AddDays(-8)},
                new Blog(){Title=".Net Core Dersleri",Description=".Net Core Desc",Content=".Net Core Dersleri içeriği",IsInHomePage=true,IsPublish=true,CategoryId=5,ImagePath="netcore.jpg",AddedDate=DateTime.Now.AddDays(-1)},
                new Blog(){Title="C# Dersleri",Description="C# Desc",Content="C# Dersleri içeriği",IsInHomePage=false,IsPublish=true,CategoryId=1,ImagePath="csharp.jpg",AddedDate=DateTime.Now.AddDays(-10)},
                new Blog(){Title="Python Dersleri",Description="Python Desc",Content="Python Dersleri içeriği",IsInHomePage=true,IsPublish=true,CategoryId=4,ImagePath="django.jpg",AddedDate=DateTime.Now.AddDays(-2)},
                new Blog(){Title="Django Dersleri",Description="Django Desc",Content="Django Dersleri içeriği",IsInHomePage=true,IsPublish=true,CategoryId=4,ImagePath="django.jpg",AddedDate=DateTime.Now.AddDays(-10)},
                new Blog(){Title="MVC5 Dersleri",Description="MVC5 Desc",Content="MVC5 Dersleri içeriği",IsInHomePage=false,IsPublish=true,CategoryId=2,ImagePath="mvc5.jpg",AddedDate=DateTime.Now.AddDays(-8)},
                new Blog(){Title=".Net Core Dersleri",Description=".Net Core Desc",Content=".Net Core Dersleri içeriği",IsInHomePage=true,IsPublish=true,CategoryId=5,ImagePath="netcore.jpg",AddedDate=DateTime.Now.AddDays(-12)},
                new Blog(){Title="C# Dersleri",Description="C# Desc",Content="C# Dersleri içeriği",IsInHomePage=false,IsPublish=true,CategoryId=1,ImagePath="csharp.jpg",AddedDate=DateTime.Now.AddDays(-10)},
                new Blog(){Title="Python Dersleri",Description="Python Desc",Content="Python Dersleri içeriği",IsInHomePage=true,IsPublish=true,CategoryId=4,ImagePath="django.jpg",AddedDate=DateTime.Now.AddDays(-23)},
            };
            foreach (var blog in blogs)
            {
                context.Blogs.Add(blog); // listeyi dolaşıp context'in bloglarına ekledik
            }
            context.SaveChanges(); // context'te yapılan değişiklikleri kayıt ettik(dbye)
            base.Seed(context);
        }
    }
}