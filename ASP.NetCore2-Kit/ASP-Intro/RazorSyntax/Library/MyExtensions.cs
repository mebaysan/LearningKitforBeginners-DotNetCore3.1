using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorSyntax.Library
{
    // Kendi html helper methodumuzu yazdık
    public static class MyExtensions // extension yazılan class static olmak zorunda ve içinde barındırdığı methodlar da statik olmak zorunda
    {
        public static MvcHtmlString Button(this HtmlHelper helper, string id, ButtonType typ, string text)
        // this HtmlHelper helper -> bu methodun hangi class'ın içinde çıkması gerektiğini belirtir
        {
            string html = String.Format("<button id='{0}' name='{0}' type='{1}'>{2}</button>", id, typ, text);
            return MvcHtmlString.Create(html); // html'i geri döndürüyoruz ve button oluşturmuş oluyoruz.

        }
        public static MvcHtmlString ButtonWithTagBuilder(this HtmlHelper helper, string id, ButtonType typ, string text)
        {
            TagBuilder tag = new TagBuilder("button"); // içeri tag'in adını parametre olarak bekler
            tag.AddCssClass("btn"); // içine istediğin kadar css class ekleyebilirsin
            tag.AddCssClass("btn-success");
            tag.GenerateId(id); // tag'in id'sini belirleyebiliriz
            tag.Attributes.Add(new KeyValuePair<string, string>("type", typ.ToString())); // tag'in typ'i belirledik.
            tag.Attributes.Add(new KeyValuePair<string, string>("name", id));
            tag.SetInnerText(text); // tag'in text'ini belirleyebiliriz.
            return MvcHtmlString.Create(tag.ToString());




        }
    }
    public enum ButtonType
    {
        button = 0,
        submit = 1,
        reset = 2
    }
}