using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Models
{
    public class HomeIndexViewModel
    {
        // Modelimiz
        public int Id { get; set; } // otomatik olarak AI primary key belirlenir
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public bool IsPublish { get; set; } // onay
        public bool IsInHomePage { get; set; } // anasayfada olsun mu olmasın mı
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}