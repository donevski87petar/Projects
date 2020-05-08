using ShoppingApp.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProduct _db;
        public HomeController(IProduct db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var model = _db.Get();
                return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}