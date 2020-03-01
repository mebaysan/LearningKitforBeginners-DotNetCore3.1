using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Identity.App_Start.IdentityConfig))]

namespace Identity.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            // OwinStartup dosyası ekliyoruz ve bunu Web.config altında tanıtmalıyız
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, // kullanıcı tanımlanma işlemi cookie'lere göre yapılacağını belirttik
                LoginPath = new PathString("/Account/Login") // kullanıcı izni olmayan bir sayfaya gelirse /Account/Login'e yönlendirilecek
            });
        }
    }
}
