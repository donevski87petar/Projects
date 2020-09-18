using ReadLater.Entities;
using ReadLater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        IBookmarkService _bookmarkService { get; set; }
        ICategoryService _categoryService { get; set; }

        public HomeController(IBookmarkService bookmarkService , ICategoryService categoryService)
        {
            _bookmarkService = bookmarkService;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var categories = _categoryService.GetCategories();
            ViewBag.CategoryId = new SelectList(categories, "ID", "Name");

            return View(categories);
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
    }
}