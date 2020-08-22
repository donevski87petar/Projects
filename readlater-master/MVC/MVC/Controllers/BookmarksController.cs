using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReadLater.Data;
using ReadLater.Entities;
using ReadLater.Services;

namespace MVC.Controllers
{
    [Authorize]
    public class BookmarksController : Controller
    {
        IBookmarkService _bookmarkService { get; set; }
        ICategoryService _categoryService { get; set; }
        public BookmarksController(IBookmarkService bookmarkService, ICategoryService categoryService)
        {
            _bookmarkService = bookmarkService;
            _categoryService = categoryService;
        }

        // GET: Bookmarks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Bookmark bookmark = _bookmarkService.GetBookmark((int)id);

            if (bookmark == null)
            {
                return HttpNotFound();
            }
            return View(bookmark);
        }

        //// GET: Bookmarks/Create
        //public ActionResult Create()
        //{
        //    var categories = _categoryService.GetCategories();
        //    ViewBag.CategoryId = new SelectList(categories , "ID", "Name");
        //    return View();
        //}

        //// POST: Bookmarks/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,URL,ShortDescription,CategoryId,CreateDate")] Bookmark bookmark )
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _bookmarkService.CreateBookmark(bookmark);
        //        return RedirectToAction("Index", "Categories");
        //    }

        //    var categories = _categoryService.GetCategories();
        //    ViewBag.CategoryId = new SelectList(categories , "ID", "Name", bookmark.CategoryId);
        //    return View(bookmark);
        //}

        // GET: Bookmarks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bookmark bookmark = _bookmarkService.GetBookmark((int)id);

            if (bookmark == null)
            {
                return HttpNotFound();
            }
            var categories = _categoryService.GetCategories();
            ViewBag.CategoryId = new SelectList(categories , "ID", "Name", bookmark.CategoryId);
            return View(bookmark);
        }

        // POST: Bookmarks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,URL,ShortDescription,CategoryId,CreateDate")] Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                _bookmarkService.UpdateBookmark(bookmark);
                return RedirectToAction("Index" , "Categories");
            }
            var categories = _categoryService.GetCategories();
            ViewBag.CategoryId = new SelectList(categories, "ID", "Name", bookmark.CategoryId);
            return RedirectToAction("Index" , "Categories");
        }

        // GET: Bookmarks/Delete/5
        public ActionResult Delete(int? id)
        {
            Bookmark bookmark = _bookmarkService.GetBookmark((int)id);
            if (bookmark == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(bookmark);
        }

        // POST: Bookmarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bookmark bookmark = _bookmarkService.GetBookmark(id);
            _bookmarkService.DeleteBookmark(bookmark);
            return RedirectToAction("Index" , "Categories");
        }

        [HttpPost]
        public ActionResult LinkClickCounter(int id)
        {
            Bookmark bookmark = _bookmarkService.GetBookmark(id);

            if(bookmark == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookmark.ClickCounter = bookmark.ClickCounter + 1;
            _bookmarkService.UpdateBookmark(bookmark);

            return View("Index");
        }

        [HttpGet]
        public ActionResult LinkStats()
        {
            List<Bookmark> bookmarks = _bookmarkService.GetAllBookmarks();

            if(bookmarks == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(bookmarks);
        }

    }
}
