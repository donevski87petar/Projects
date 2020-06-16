using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Data;
using RestaurantApp.Models;
using RestaurantApp.Models.ViewModels;

namespace RestaurantApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubcategoryController : Controller
    {
        ApplicationDbContext _db;
        public SubcategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        [TempData]
        public string StatusMessage { get; set; }


        public async Task<IActionResult> Index()
        {
            var subcategories = await _db.Subcategories.Include(c => c.Category).ToListAsync();
            return View(subcategories);
        }

        public async Task<IActionResult> Create()
        {
            SubcategoryAndCategoryViewModel model = new SubcategoryAndCategoryViewModel()
            {
                CategoryList = await _db.Categories.ToListAsync(),
                Subcategory = new Models.Subcategory(),
                SubcategoryList = await _db.Subcategories.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubcategoryAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesSubCategoryExists = _db.Subcategories.Include(s => s.Category).Where(s => s.Name == model.Subcategory.Name && s.Category.Id == model.Subcategory.CategoryId);

                if (doesSubCategoryExists.Count() > 0)
                {
                    //Error
                    StatusMessage = "Error : Sub Category exists under " + doesSubCategoryExists.First().Category.Name + " category. Please use another name.";
                }
                else
                {
                    _db.Subcategories.Add(model.Subcategory);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            SubcategoryAndCategoryViewModel modelVM = new SubcategoryAndCategoryViewModel()
            {
                CategoryList = await _db.Categories.ToListAsync(),
                Subcategory = model.Subcategory,
                SubcategoryList = await _db.Subcategories.OrderBy(p => p.Name).Select(p => p.Name).ToListAsync(),
                StatusMessage = StatusMessage
            };
            return View(modelVM);
        }

        [ActionName("GetSubCategory")]
        public async Task<IActionResult> GetSubCategory(int id)
        {
            List<Subcategory> subcategories = new List<Subcategory>();

            subcategories = await (from subcategory in _db.Subcategories
                                   where subcategory.CategoryId == id
                                   select subcategory).ToListAsync();
            return Json(new SelectList(subcategories, "Id", "Name"));
        }



        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _db.Subcategories.SingleOrDefaultAsync(m => m.Id == id);

            if (subCategory == null)
            {
                return NotFound();
            }

            SubcategoryAndCategoryViewModel model = new SubcategoryAndCategoryViewModel()
            {
                CategoryList = await _db.Categories.ToListAsync(),
                Subcategory = subCategory,
                SubcategoryList = await _db.Subcategories.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync()
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , SubcategoryAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesSubCategoryExists = _db.Subcategories.Include(s => s.Category).Where(s => s.Name == model.Subcategory.Name && s.Category.Id == model.Subcategory.CategoryId);

                if (doesSubCategoryExists.Count() > 0)
                {
                    //Error
                    StatusMessage = "Error : Sub Category exists under " + doesSubCategoryExists.First().Category.Name + " category. Please use another name.";
                }
                else
                {
                    var subCatFromDb = await _db.Subcategories.FindAsync(id);
                    subCatFromDb.Name = model.Subcategory.Name;

                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            SubcategoryAndCategoryViewModel modelVM = new SubcategoryAndCategoryViewModel()
            {
                CategoryList = await _db.Categories.ToListAsync(),
                Subcategory = model.Subcategory,
                SubcategoryList = await _db.Subcategories.OrderBy(p => p.Name).Select(p => p.Name).ToListAsync(),
                StatusMessage = StatusMessage
            };
            modelVM.Subcategory.Id = id;
            return View(modelVM);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subCategory = await _db.Subcategories.Include(s => s.Category).SingleOrDefaultAsync(m => m.Id == id);
            if (subCategory == null)
            {
                return NotFound();
            }

            return View(subCategory);
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subCategory = await _db.Subcategories.Include(s => s.Category).SingleOrDefaultAsync(m => m.Id == id);
            if (subCategory == null)
            {
                return NotFound();
            }

            return View(subCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCategory = await _db.Subcategories.SingleOrDefaultAsync(m => m.Id == id);
            _db.Subcategories.Remove(subCategory);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }





    }
}