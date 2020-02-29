using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Models
{
    public class CategoryIndexViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int BlogCount { get; set; }
    }
}