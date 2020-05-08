using Microsoft.AspNet.Identity;
using PagedList;
using ShoppingApp.Data.Models;
using ShoppingApp.Data.Services;
using ShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProduct _db;
        public ProductsController(IProduct db)
        {
            _db = db;
        }

        //public IProduct Product { get; }

        // GET: Products
        public ActionResult AllProducts(string gender , string productType, int? page)
        {
            try
            {
                if (gender == "Man")
                {
                    if (productType == "Shoes")
                    {
                        var model = _db.Get()
                        .Where(p => p.Cathegory == Data.Enums.Cathegory.Man && p.ProductType.ToString() == "Shoes")
                        .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                    else if (productType == "TShirts")
                    {
                        var model = _db.Get()
                        .Where(p => p.Cathegory == Data.Enums.Cathegory.Man && p.ProductType.ToString() == "TShirts")
                        .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                    else if (productType == "Trousers")
                    {
                        var model = _db.Get()
                        .Where(p => p.Cathegory == Data.Enums.Cathegory.Man && p.ProductType.ToString() == "Trousers")
                        .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                    else if (productType == "Tights")
                    {
                        var model = _db.Get()
                        .Where(p => p.Cathegory == Data.Enums.Cathegory.Man && p.ProductType.ToString() == "Tights")
                        .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                    else if (productType == "Hoodies")
                    {
                        var model = _db.Get()
                        .Where(p => p.Cathegory == Data.Enums.Cathegory.Man && p.ProductType.ToString() == "Hoodies")
                        .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                    else if (productType == "Jackets")
                    {
                        var model = _db.Get()
                        .Where(p => p.Cathegory == Data.Enums.Cathegory.Man && p.ProductType.ToString() == "Jackets")
                        .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                    else
                    {
                        var model = _db.Get()
                        .Where(p => p.Cathegory == Data.Enums.Cathegory.Man)
                        .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                }
                else if (gender == "Woman")
                {
                    if (productType == "Shoes")
                    {
                        var model = _db.Get()
                        .Where(p => p.Cathegory == Data.Enums.Cathegory.Woman && p.ProductType.ToString() == "Shoes")
                        .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                    else if (productType == "TShirts")
                    {
                        var model = _db.Get()
                        .Where(p => p.Cathegory == Data.Enums.Cathegory.Woman && p.ProductType.ToString() == "TShirts")
                        .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                    else if (productType == "Trousers")
                    {
                        var model = _db.Get()
                        .Where(p => p.Cathegory == Data.Enums.Cathegory.Woman && p.ProductType.ToString() == "Trousers")
                        .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                    else if (productType == "Tights")
                    {
                        var model = _db.Get()
                        .Where(p => p.Cathegory == Data.Enums.Cathegory.Woman && p.ProductType.ToString() == "Tights")
                        .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                    else if (productType == "Hoodies")
                    {
                        var model = _db.Get()
                        .Where(p => p.Cathegory == Data.Enums.Cathegory.Woman && p.ProductType.ToString() == "Hoodies")
                        .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                    else if (productType == "Jackets")
                    {
                        var model = _db.Get()
                        .Where(p => p.Cathegory == Data.Enums.Cathegory.Woman && p.ProductType.ToString() == "Jackets")
                        .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                    else
                    {
                        var model = _db.Get()
                        .Where(p => p.Cathegory == Data.Enums.Cathegory.Woman)
                        .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                }
                else if (gender == "AllProducts")
                {
                    if (productType == "Shoes")
                    {
                        var model = _db.Get()
                        .Where(p => p.ProductType.ToString() == productType)
                        .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                    else if (productType == "TShirts")
                    {
                        var model = _db.Get()
                            .Where(p => p.ProductType.ToString() == productType)
                            .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                    else if (productType == "Trousers")
                    {
                        var model = _db.Get()
                         .Where(p => p.ProductType.ToString() == productType)
                         .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                    else if (productType == "Tights")
                    {
                        var model = _db.Get()
                         .Where(p => p.ProductType.ToString() == productType)
                         .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                    else if (productType == "Hoodies")
                    {
                        var model = _db.Get()
                         .Where(p => p.ProductType.ToString() == productType)
                         .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                    else if (productType == "Jackets")
                    {
                        var model = _db.Get()
                             .Where(p => p.ProductType.ToString() == productType)
                             .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                    else
                    {
                        var model = _db.Get()
                             .ToPagedList(page ?? 1, 12);
                        return View(model);
                    }
                }
                else
                {
                    return View(_db.Get().ToPagedList(page ?? 1, 12));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public ActionResult ProductDetails(int id)
        {
            var model = _db.Get(id);
            if(model == null)
            {
                return View("Error");
            }
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(Product product)
        {
            //Set the user ID 
            product.UserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                    //Add image logic
                    string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                    string extension = Path.GetExtension(product.ImageFile.FileName);

                    //add date time now to make unique names always
                    fileName = DateTime.Now.ToString("yymmssfff") + extension;

                    product.ImagePath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);

                    //save in folder images
                    product.ImageFile.SaveAs(fileName);

                    _db.Add(product);
                    ModelState.Clear();


                TempData["MessageCreate"] = "The Product was added to the database.";
                return RedirectToAction("ProductDetails", new { id = product.Id });
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var model = _db.Get(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Update(product);
                TempData["MessageEdit"] = "The Product was succesfully updated";
                return RedirectToAction("ProductDetails", new { id = product.Id });
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            var model = _db.Get(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int id , FormCollection form)
        {
            _db.Delete(id);
            TempData["MessageDelete"] = "The Product was succesfully deleted";
            return RedirectToAction("AllProducts");
        }

        [HttpGet]
        public ActionResult ShoppingCart()
        {
            var model = Session["cart"];
            return View(model);
        }

        [HttpPost]
        public ActionResult ShoppingCart(int id)
        {
            if (Session["cart"] == null)
            {
                List<Product> cart = new List<Product>();
                Product product = _db.Get(id);
                cart.Add(product);

                Session["cart"] = cart;
                TempData["ProductAdded"] = "The Product was succesfully added to Your Shopping cart";
            }
            else
            {
                List<Product> cart = (List<Product>)Session["cart"];
                Product product = _db.Get(id);
                cart.Add(product);
                Session["cart"] = cart;
                TempData["ProductAdded"] = "The Product was added to your shopping cart";
            }
            return View("ShoppingCart");
        }


        [HttpPost]
        public ActionResult RemoveFromCart(int id)

        { 
            List<Product> cart = (List<Product>)Session["cart"];
            Product product = cart.FirstOrDefault(p => p.Id == id);
            if (cart.Contains(product))
            {
                cart.Remove(product);
            }
            cart = (List<Product>)Session["cart"];

            TempData["ProductRemovedCart"] = "The Product was removed from your shopping cart";

            return View("ShoppingCart");
        }

        public ActionResult Payment()
        {
            List<Product> cart = (List<Product>)Session["cart"];
            double total = 0;
            foreach (var item in cart)
            {
                total += item.Price;
            }
            return View(total);
        }
    }
}