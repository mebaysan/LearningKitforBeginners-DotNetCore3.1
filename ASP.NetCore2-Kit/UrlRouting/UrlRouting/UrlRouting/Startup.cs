using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace UrlRouting
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                RequestPath = "/modules"
            });
            //app.UseMvcWithDefaultRoute(); // controller/action/id?
            app.UseMvc(routes =>
            {
                // route'larımızın çalışabilmesi için onları sıraya koymak da çok önemlidir. spesifik route'ları daha üstlere yerleştirmeliyiz.
                routes.MapRoute(name: "Shop2", template: "shop/newest", defaults: new { controller = "Product", action = "Index" }); // shop/newest deyince otomatik olarak Product controller'a gider ve Index action'a gider.
                routes.MapRoute(name: "Shop1", template: "shop/{action}", defaults: new { controller = "Product" }); // shop/Index deyince otomatik olarak Product controllere gidecek -> localhost:50109/shop/newest
                routes.MapRoute(name: "a", template: "a{controller}/{action=Index}"); // localhost:50109/ahome
                routes.MapRoute(name: "catalog", template: "catalog/{controller}/{action=Index}"); // localhost:50109/catalog/product
                routes.MapRoute(name: "parametreli", template: "{controller=Product}/{action=Details}/{id=0}/{*extraparams}"); // id gönderilmezse id 0 olsun dedik. ve extra parametreler alabilir dedik   localhost:50109/product/details/15, localhost:50109/product/details/2/deneme/sil/g%C3%BCncelle
                /*
                 * routes.MapRoute(name: "parametreli2", template: "{controller}/{action}/{id}", defaults : new { controller = "Product", action = "Details" },constraints: new { id = new IntRouteConstraint() });
                 *  defaultları belirledik ve constaints diyerek id alanına sadece sayısal bir şey gelsin dedik. Bunu şu şekilde de tanımlayabilirdik;
                 *  routes.MapRoute(name: "parametreli2", template: "{controller}/{action}/{id:int}", defaults : new { controller = "Product", action = "Details" });
                 */

                 /*                 Birden fazla constaint yazmak istersek!
                  * 
                  * routes.MapRoute(name: "parametreli2", 
                     template: "{controller}/{action}/{id}", 
                     defaults : new { controller = "Product", action = "Details" },
                     constraints: new { 
                            id = new CompositeRouteConstraint( 
                            new IRouteConstraint[]
                                { new AlphaRouteConstraint(), a-z arasında bir parametre alacak
                                new MinLengthRouteConstraint(3)}) minimum 3 harf alacak
                   });
                  */
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}"); // uygulama çalıştığında varsayılan olarak Home controller'a gidecek. action olarak otomatik olarak Index'e gidecek.


            });
        }
    }
}
