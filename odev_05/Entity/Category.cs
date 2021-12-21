using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace odev_05.Entity
{
    public class Category
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public List<product> Products { get; set; }

    }
}