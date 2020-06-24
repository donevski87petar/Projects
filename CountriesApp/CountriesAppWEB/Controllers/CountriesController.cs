using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CountriesAppWEB.Models;
using CountriesAppWEB.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CountriesAppWEB.Controllers
{
    [Authorize]
    public class CountriesController : Controller
    {

        private readonly ICountryRepository _countryRepository;
        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }



        public IActionResult Index()
        {
            return View(new Country() { });
        }





        public async Task<IActionResult> GetAllCountries()
        {
            return Json(new { data = await _countryRepository.GetAllAsync(SD.CountriesAPIPath) });
        }





        public async Task<IActionResult> Upsert(int? id)
        {
            Country obj = new Country();

            if (id == null)
            {
                //this will be true for Insert/Create
                return View(obj);
            }

            //Flow will come here for update
            obj = await _countryRepository.GetAsync(SD.CountriesAPIPath, id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Country obj)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    obj.Flag = p1;
                }
                else
                {
                    var objFromDb = await _countryRepository.GetAsync(SD.CountriesAPIPath, obj.Id);
                    obj.Flag = objFromDb.Flag;
                }
                if (obj.Id == 0)
                {
                    await _countryRepository.CreateAsync(SD.CountriesAPIPath, obj);
                }
                else
                {
                    await _countryRepository.UpdateAsync(SD.CountriesAPIPath + obj.Id, obj);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(obj);
            }
        }





        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _countryRepository.DeleteAsync(SD.CountriesAPIPath, id);
            if (status)
            {
                return Json(new { success = true, message = "Delete Successful" });
            }
            return Json(new { success = false, message = "Delete Not Successful" });
        }




    }
}