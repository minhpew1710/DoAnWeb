using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopDTA.Models;

namespace ShopDTA.Controllers
{
    public class HomeController : Controller
    {
        DTAShopDBContext db = new DTAShopDBContext();
        public ActionResult Index()
        {
            var model = db.Categories.Where(p => p.Products.Count > 4).ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Category()
        {
            var model = db.Categories;
            return PartialView("_Category", model);
        }
        public ActionResult SaleOff()
        {
            var model = db.Products.Where(p=>p.Discount>0 ).OrderBy(p=>Guid.NewGuid()).Take(2);
            return PartialView("_SaleOff", model);
        }
        public ActionResult Special()
        {
            var model = db.Products.Where(p => p.Special == true).Take(5);
            return PartialView("_BestSeller", model);
        }
        public ActionResult Search()
        {
            var name = Request["term"];

            var data = db.Products
                .Where(p => p.Name.Contains(name))
                .Select(p => p.Name).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}