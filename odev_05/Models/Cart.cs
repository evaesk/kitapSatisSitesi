using odev_05.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace odev_05.Models
{
    public class Cart
    {
        private List<Cartline> _cartlines = new List<Cartline>();
        public List<Cartline>  Cartlines
        {
            get { return _cartlines; }
        }
        public void AddProduct(product product,int quantity)
        {
            var line = _cartlines.FirstOrDefault(i => i.product.Id == product.Id);
            if (line == null) 
            {
                _cartlines.Add(new Cartline() { product = product, Quantity = quantity });
            }
            else 
            {
                line.Quantity += quantity;
            }
        }
         public void DeleteProduct(product product) 
         {
            _cartlines.RemoveAll(i => i.product.Id == product.Id);

         }
        public double Total() 
        {
            return _cartlines.Sum(i => i.product.Price * i.Quantity);
        }
        public void Clear() 
        {
            _cartlines.Clear();
        }
    }
   public class Cartline
    {
        public product product { get; set; }
        public int Quantity{ get; set; }
    }
  
}