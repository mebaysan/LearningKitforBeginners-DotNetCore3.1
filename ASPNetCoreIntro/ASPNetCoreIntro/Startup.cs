using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Customer/Error"); // Customer altında Error view'ı çalışacak
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // conventional routing
                endpoints.MapControllerRoute(
                    name: "default", // default olarak bu routing kullanılır
                    pattern: "{controller=Product}/{action=Index}/{id?}"); // default routing ayarlarını belirlediğimiz kısım

                endpoints.MapControllerRoute(
                    name: "admin", // routing'e isim verdik
                    pattern: "admin/{controller=Admin}/{action=Index}/{id?}"); // routing tasarımını yazdık -> domain.com/admin/controller_name/action_name/id? -> admin/ sabit yani
            });
        }
    }
}
