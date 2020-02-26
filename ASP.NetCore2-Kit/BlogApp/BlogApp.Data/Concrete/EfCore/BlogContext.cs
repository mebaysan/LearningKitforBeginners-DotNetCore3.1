using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data.Concrete.EfCore
{
    public class BlogContext : DbContext // DbContext'ten türettik
    {
        public BlogContext(DbContextOptions<BlogContext> options) 
            : base(options) // entity framework core ayarını yaptık burada
        {

        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
