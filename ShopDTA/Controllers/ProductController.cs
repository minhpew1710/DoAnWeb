using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopDTA.Models;
namespace ShopDTA.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        DTAShopDBContext db = new DTAShopDBContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category(int CategoryID=0)
        {
            if (CategoryID!=0)
            {
                var model = db.Products.Where(p => p.CategoryId == CategoryID);
                return View(model);
            }
            return View();
        }
        public ActionResult Detail(int id)
        {
            var model = db.Products.Find(id);
            model.Views++;
            db.SaveChanges();

            var views = Request.Cookies["views"];

            if (views == null)
            {
                views = new HttpCookie("views");
            }
            views.Values[id.ToString()] = id.ToString();
            views.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(views);

            var keys = views.Values
                .AllKeys.Select(k => int.Parse(k)).ToList();
            ViewBag.Views = db.Products
                .Where(p => keys.Contains(p.Id));

            ViewBag.Top = db.Products.Where(p => p.Id > 0).OrderByDescending(p => p.Views).Take(10).ToList();
            return View(model);
        }
        public ActionResult Search(String Keywords = "")
        {
            if (Keywords != "")
            {
                var model = db.Products
                    .Where(p => p.Name.Contains(Keywords));
                return View(model);
            }
            return View(db.Products);
        }
    }
}