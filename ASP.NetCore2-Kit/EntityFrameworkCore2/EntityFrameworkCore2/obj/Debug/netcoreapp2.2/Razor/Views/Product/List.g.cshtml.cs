#pragma checksum "C:\Users\meb\source\repos\EntityFrameworkCore2\EntityFrameworkCore2\Views\Product\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7eb1b6371116d0d366e2f5c6bf8a331b1429406e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_List), @"mvc.1.0.view", @"/Views/Product/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/List.cshtml", typeof(AspNetCore.Views_Product_List))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\meb\source\repos\EntityFrameworkCore2\EntityFrameworkCore2\Views\_ViewImports.cshtml"
using EntityFrameworkCore2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7eb1b6371116d0d366e2f5c6bf8a331b1429406e", @"/Views/Product/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0016605d1989e3d4f8491b7a1b7c0390f3afdc3c", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\meb\source\repos\EntityFrameworkCore2\EntityFrameworkCore2\Views\Product\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(117, 25, true);
            WriteLiteral("\r\n<h1>List</h1>\r\n<br />\r\n");
            EndContext();
#line 9 "C:\Users\meb\source\repos\EntityFrameworkCore2\EntityFrameworkCore2\Views\Product\List.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
            BeginContext(175, 8, true);
            WriteLiteral("    <h2>");
            EndContext();
            BeginContext(184, 9, false);
#line 11 "C:\Users\meb\source\repos\EntityFrameworkCore2\EntityFrameworkCore2\Views\Product\List.cshtml"
   Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(193, 15, true);
            WriteLiteral("</h2>\r\n    <h4>");
            EndContext();
            BeginContext(209, 13, false);
#line 12 "C:\Users\meb\source\repos\EntityFrameworkCore2\EntityFrameworkCore2\Views\Product\List.cshtml"
   Write(item.Category);

#line default
#line hidden
            EndContext();
            BeginContext(222, 15, true);
            WriteLiteral("</h4>\r\n    <h5>");
            EndContext();
            BeginContext(238, 10, false);
#line 13 "C:\Users\meb\source\repos\EntityFrameworkCore2\EntityFrameworkCore2\Views\Product\List.cshtml"
   Write(item.Price);

#line default
#line hidden
            EndContext();
            BeginContext(248, 7, true);
            WriteLiteral("</h5>\r\n");
            EndContext();
#line 14 "C:\Users\meb\source\repos\EntityFrameworkCore2\EntityFrameworkCore2\Views\Product\List.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
