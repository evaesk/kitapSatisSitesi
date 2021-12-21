using odev_05.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace odev_05.Models
{
    public class AdminOrder
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderState OrderState { get; set; }
        public int Count { get; set; }
    }
}
