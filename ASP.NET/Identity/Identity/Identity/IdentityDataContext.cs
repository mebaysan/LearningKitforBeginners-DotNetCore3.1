using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Identity.Identity
{
    public class IdentityDataContext : IdentityDbContext<MyUser> // Identity işlemleri için de bir context belirlemeliyiz. Bu Context sınıfımızı da IdentityDbContext sınıfından türetmeliyiz ve Hangi tipte IdentityUser ile çalışacaksak belirtmeliyiz.
    {
        public IdentityDataContext() : base("identityConnection") // web.config içerisinde connection string
        {

        }
    }
}