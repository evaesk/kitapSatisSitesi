using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace odev_05.Entity
{
    public class product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Page { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public bool Slider { get; set; }
        public bool IsHome { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsApproved { get; set; }
        public int CategoryId { get; set; }
        public string Date { get; set; }
        public string Language { get; set; }
        public string PaperType { get; set; }
        public string Size { get; set; }
        public string LittleDescription { get; set; }
        public string Translater { get; set; }
        public string image2 { get; set; }

        public Category Category { get; set; }
    }
}