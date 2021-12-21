using odev_05.Entity;
using odev_05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace odev_05.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DataContext db = new DataContext();
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            StateModel model = new StateModel();
            model.BekleyenSiparisSayisi = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList().Count();
            model.AlınanSiparisSayisi = db.Orders.Where(i => i.OrderState == OrderState.Alındı).ToList().Count();
            model.PaketlenenSiparisSayisi = db.Orders.Where(i => i.OrderState == OrderState.Paketlendi).ToList().Count();
            model.KargolananSiparisSayisi = db.Orders.Where(i => i.OrderState == OrderState.Kargolandı).ToList().Count();
            model.UrunSayisi = db.Products.Count();
            model.SiparisSayisi = db.Orders.Count();
            return View(model);
        }
        public PartialViewResult BildirimMenusu() 
        {
            var bildirim = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList();
            return PartialView(bildirim);
        }
    }
}