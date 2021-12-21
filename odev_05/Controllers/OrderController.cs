﻿using odev_05.Entity;
using odev_05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace odev_05.Controllers
{
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrder()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.OrderLines.Count
            }).OrderByDescending(i => i.OrderDate).ToList();
            return View(orders);
        }
        public ActionResult Details(int Id) 
        {
            var model = db.Orders.Where(i => i.Id == Id).Select(i => new OrderDetails()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                UserName = i.UserName,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Adres = i.Adres,
                Sehir = i.Sehir,
                Semt = i.Semt,
                Mahalle = i.Mahalle,
                PostaKodu = i.PostaKodu,
                OrderLines = i.OrderLines.Select(x => new OrderLineModel()
                {
                    ProductId = x.productId,
                    Image = x.product.Image,
                    ProductName = x.product.Name,
                    Quantity = x.Quantity,
                    Price = x.Price
                }).ToList()

            }).FirstOrDefault();
            return View(model);
        }
        public ActionResult UpdateOrderState(int OrderId,OrderState Orderstate) 
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);
            if (order != null) 
            {
                order.OrderState = Orderstate;
                db.SaveChanges();
                TempData["mesaj"] = "Bilgiler Kaydedildi";
                return RedirectToAction("Details", new { id = OrderId });
            }
            return RedirectToAction("Index");
        }
        public ActionResult BekleyenSiparisler() 
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList();
            return View(model);
        }
        public ActionResult AlınanSiparisler()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Alındı).ToList();
            return View(model);
        }
        public ActionResult PaketlenenSiparisler()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Paketlendi).ToList();
            return View(model);
        }
        public ActionResult KargolananSiparisler()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Kargolandı).ToList();
            return View(model);
        }
    }
    
    
}