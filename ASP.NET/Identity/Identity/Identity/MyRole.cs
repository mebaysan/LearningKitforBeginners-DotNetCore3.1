using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Identity.Identity
{
    public class MyRole : IdentityRole // kendi rollerimizi yazarken de IdentityRole sınıfından miras almalıyız.
    {
        public string Description { get; set; }
    }
}