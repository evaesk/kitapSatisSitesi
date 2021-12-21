using odev_05.Entity;
using odev_05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace odev_05.Controllers
{
    public class CartController : Controller
    {
        DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        private void SaveOrder(Cart cart,ShippingDetails model)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(1111, 9999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.UserName = User.Identity.Name;
            order.OrderState = OrderState.Bekleniyor;
            order.Adres = model.Adres;
            order.Sehir = model.Sehir;
            order.Semt = model.Semt;
            order.Mahalle = model.Mahalle;
            order.PostaKodu = model.PostaKodu;
            order.OrderLines = new List<OrderLine>();
            foreach (var item in cart.Cartlines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = item.Quantity;
                orderline.Price = item.Quantity * item.product.Price;
                orderline.productId = item.product.Id;
                order.OrderLines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }  
        [HttpPost]
        public ActionResult Checkout(ShippingDetails model)
        {
            var cart = GetCart();
            if (cart.Cartlines.Count==0) 
            {
                ModelState.AddModelError("ÜrünYok", "Sepetinizde ürün bulunmamaktadır...");
            }
            if (ModelState.IsValid) 
            {
                SaveOrder(cart, model);
                cart.Clear();
                return View("SiparişTamamlandı");
            }
            else 
            {
                return View(model);
            }
            
        }  
        public PartialViewResult Summary() 
        {
            return PartialView(GetCart());
        } 
        public PartialViewResult Summary1() 
        {
            return PartialView(GetCart());
        }
        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product!=null) 
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }  
        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product!=null) 
            {
                GetCart().AddProduct(product, 1);           
            }
            return RedirectToAction("Index");
        }
        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if(cart==null) 
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}