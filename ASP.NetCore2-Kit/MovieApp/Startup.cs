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

namespace MovieApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles(); // default olarak wwwroot klasörü dışarıya açılmış olur ve bunun içindeki bütün style dosyalarına ulaşabiliriz. => /css/deneme.css veya /img/resim.jpg -> bu şekilde dosya yolları kullanılır. wwwroot'u otomatik algılayacak
            app.UseStaticFiles(new StaticFileOptions{
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),
                RequestPath = "/modules" // takma isim vermiş olduk
            }); // bu da extra olarak dışarıya açacağımız dosya yolu. modules/bootstrap/dist/css/bootstrap.min.css olmuş oldu
            // GÜZEL BİLGİ => ctrl + . -> usingleri hızlıca eklememizi sağlar
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvcWithDefaultRoute();

            
        }
    }
}
