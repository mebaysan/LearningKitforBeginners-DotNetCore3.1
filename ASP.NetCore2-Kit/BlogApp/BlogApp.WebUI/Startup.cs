using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;


namespace BlogApp.WebUI
{
    public class Startup
    {

        public Startup(IConfiguration configuration) // bu constructor'ı elimizle ekledik. .net core 2.2'de burası gelmiyor bu sebeple elle ekledik.
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; } // burayı da elle ekledik
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IBlogRepository, EfBlogRepository>(); // IBlogRepository çağırdığımız anda efblogrepository'i çağıracak
            services.AddTransient<ICategoryRepository, EfCategoryRepository>();
            services.AddDbContext<BlogContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("BlogApp.WebUI"))); // MigrationsAssembly -> migrations'ın nereye kurulacağı
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles(); // wwwroot

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                RequestPath = "/modules"
            }); // dosya yolunu gösteriyoruz ve dosyaları dışarı açıyoruz

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
            SeedData.Seed(app); // oluşturduğumuz seedData'yı uygulamaya gönderiyoruz.
        }
    }
}
