using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Entity
{
    public class Blog
    {
        public int BlogId { get; set; } // sınıfın birinci anahtarı olduğunu algılıyor. veritabanı kurarken ona göre oto kuruyor.
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        [BindNever] // form üzerinden gönderilmeyeceği için BindNever ile işaretledik
        public DateTime Date { get; set; }
        public bool isApproved { get; set; }
        public bool isHome { get; set; }
        public bool isSlider { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } // her bloğun bir adet kategorisi vardır
    }
}
