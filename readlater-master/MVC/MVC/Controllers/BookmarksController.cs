using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MVC.Models;
using ReadLater.Data;
using ReadLater.Entities;
using ReadLater.Services;

namespace MVC.Controllers
{
    [Authorize]
    public class BookmarksController : Controller
    {
        IBookmarkService _bookmarkService;
        ICategoryService _categoryService;

        public BookmarksController(IBookmarkService bookmarkService, 
                                   ICategoryService categoryService)
        {
            _bookmarkService = bookmarkService;
            _categoryService = categoryService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,URL,ShortDescription,CategoryId,CreateDate,isShared")] Bookmark bookmark)
        {
            if(bookmark.CategoryId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
            }

            if (ModelState.IsValid)
            {
                bookmark.PostedBy = User.Identity.Name;
                _bookmarkService.CreateBookmark(bookmark);
                return RedirectToAction("Index", "Categories");
            }

            var categories = _categoryService.GetCategories();
            ViewBag.CategoryId = new SelectList(categories, "ID", "Name", bookmark.CategoryId);
            return View(bookmark);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,URL,ShortDescription,CategoryId,CreateDate,ClickCounter,isShared")] Bookmark bookmark , int id)
        {
            if(bookmark == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

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
            if (bookmarks == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var currentUserId = User.Identity.GetUserId();
            IEnumerable<Bookmark> userBookmarks = bookmarks.Where(b => b.Category.UserId == currentUserId);

            ViewBag.userEmail = User.Identity.GetUserName();
            ViewBag.totalCategories = _categoryService.GetCategories().Count();
            ViewBag.totalLinks = userBookmarks.Count();

            int totalClicks = 0;
            foreach (var item in userBookmarks)
            {
                totalClicks += item.ClickCounter;
            }
            ViewBag.totalClicks = totalClicks;

            return View(userBookmarks);
        }

        [HttpGet]
        public ActionResult SharedLinks()
        {
            IEnumerable<Bookmark> bookmarks = _bookmarkService.GetAllBookmarks().Where(b => b.isShared == true);
            if(bookmarks == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(bookmarks);
        }


    }
}
