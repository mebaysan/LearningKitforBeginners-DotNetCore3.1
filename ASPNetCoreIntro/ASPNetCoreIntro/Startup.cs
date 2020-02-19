using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreIntro.Services.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASPNetCoreIntro
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) // çalýþma anýnda çalýþacak methodlar. CustomerController içerisindeki ILogger servisimizi burada belirtmeliyiz (Dependency Injection)
        {
            services.AddControllersWithViews();
            //services.AddScoped<ILogger, DatabaseLogger>(); // bu þu demektir -> birisi constructor'ýnda ILogger isterse ona DatabaseLogger'ý ver. Kim ILogger isterse mesela ctor'da 2 adet ILogger instance isterse o ikisi de aslýnda tek bir ILogger instance'dir. Tek istekte ne kadar ILogger istenirse istensin hepsine ayný instance'i verir.
            services.AddSingleton<ILogger, DatabaseLogger>(); // bu þu demektir -> birisi constructor'ýnda ILogger isterse ona DatabaseLogger'ý ver. Fakat arkada 1 adet ILogger instance oluþturur ctor'da bunu isteyen herkese ayný instance'ý verir. Ayný zamanda singleton "bellekte tutulur"
            //services.AddTransient<ILogger, DatabaseLogger>(); // bu þu demektir -> birisi constructor'ýnda ILogger isterse ona DatabaseLogger'ý ver. Tek istekte ne kadar ILogger istenirse o kadar instance oluþturur ve her birine ayrý instance'ler verir.
            services.AddSession(); // session alt yapýsýný sisteme tanýmlýyoruz/dahil ediyoruz
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Customer/Error"); // Customer altýnda Error view'ý çalýþacak
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession(); // middleware olarak da session altyapýsýný eklemeliyiz

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // conventional routing
                endpoints.MapControllerRoute(
                    name: "default", // default olarak bu routing kullanýlýr
                    pattern: "{controller=Product}/{action=Index}/{id?}"); // default routing ayarlarýný belirlediðimiz kýsým

                endpoints.MapControllerRoute(
                    name: "admin", // routing'e isim verdik
                    pattern: "admin/{controller=Admin}/{action=Index}/{id?}"); // routing tasarýmýný yazdýk -> domain.com/admin/controller_name/action_name/id? -> admin/ sabit yani
            });
        }
    }
}
