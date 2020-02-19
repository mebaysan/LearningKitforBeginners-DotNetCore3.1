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
        public void ConfigureServices(IServiceCollection services) // �al��ma an�nda �al��acak methodlar. CustomerController i�erisindeki ILogger servisimizi burada belirtmeliyiz (Dependency Injection)
        {
            services.AddControllersWithViews();
            //services.AddScoped<ILogger, DatabaseLogger>(); // bu �u demektir -> birisi constructor'�nda ILogger isterse ona DatabaseLogger'� ver. Kim ILogger isterse mesela ctor'da 2 adet ILogger instance isterse o ikisi de asl�nda tek bir ILogger instance'dir. Tek istekte ne kadar ILogger istenirse istensin hepsine ayn� instance'i verir.
            services.AddSingleton<ILogger, DatabaseLogger>(); // bu �u demektir -> birisi constructor'�nda ILogger isterse ona DatabaseLogger'� ver. Fakat arkada 1 adet ILogger instance olu�turur ctor'da bunu isteyen herkese ayn� instance'� verir. Ayn� zamanda singleton "bellekte tutulur"
            //services.AddTransient<ILogger, DatabaseLogger>(); // bu �u demektir -> birisi constructor'�nda ILogger isterse ona DatabaseLogger'� ver. Tek istekte ne kadar ILogger istenirse o kadar instance olu�turur ve her birine ayr� instance'ler verir.
            services.AddSession(); // session alt yap�s�n� sisteme tan�ml�yoruz/dahil ediyoruz
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
                app.UseExceptionHandler("/Customer/Error"); // Customer alt�nda Error view'� �al��acak
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession(); // middleware olarak da session altyap�s�n� eklemeliyiz

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // conventional routing
                endpoints.MapControllerRoute(
                    name: "default", // default olarak bu routing kullan�l�r
                    pattern: "{controller=Product}/{action=Index}/{id?}"); // default routing ayarlar�n� belirledi�imiz k�s�m

                endpoints.MapControllerRoute(
                    name: "admin", // routing'e isim verdik
                    pattern: "admin/{controller=Admin}/{action=Index}/{id?}"); // routing tasar�m�n� yazd�k -> domain.com/admin/controller_name/action_name/id? -> admin/ sabit yani
            });
        }
    }
}
