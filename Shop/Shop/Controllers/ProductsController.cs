using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Data.Repository.IRepository;
using Shop.DomainModels.Models;
using Shop.ViewModels;
using X.PagedList;

namespace Shop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository , IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IActionResult AllProducts(int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 5;

            var modelList = _productRepository.GetAll();
            var viewModelList = new List<ProductViewModel>();
            foreach (var item in modelList)
            {
                viewModelList.Add(_mapper.Map<ProductViewModel>(item));
            }

            ViewBag.ProductsCount = _productRepository.GetAll().Count();

            var viewModelPagedList = viewModelList.ToPagedList(pageNumber, pageSize);
            return View(viewModelPagedList);
        }

        public IActionResult ProductDetails(int id)
        {
            Product product = _productRepository.GetById(id);
            ProductViewModel productViewModel = _mapper.Map<ProductViewModel>(product); 
            if (productViewModel == null)
            {
                return View("Error");
            }
            return View(productViewModel);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            if (ModelState.IsValid)
            {
                _productRepository.CreateProduct(product);
                return RedirectToAction("ProductDetails", new { id = product.ProductId });
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            Product product = _productRepository.GetById(id);
            ProductViewModel productViewModel = _mapper.Map<ProductViewModel>(product);
            if(productViewModel == null)
            {
                return View("Error");
            }
            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(int id , ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _productRepository.UpdateProduct(product);
                //TempData["MessageEdit"] = "The Product was succesfully updated";
                return RedirectToAction("ProductDetails", new { id = product.ProductId });
            }
            return View();
        }

        [HttpGet]
        public IActionResult RemoveProduct(int id)
        {
            Product product = _productRepository.GetById(id);
            ProductViewModel productViewModel = _mapper.Map<ProductViewModel>(product);
            if (productViewModel == null)
            {
                return View("Error");
            }
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult RemoveProduct(int id, ProductViewModel productViewModel)
        {
            _productRepository.DeleteProduct(id);
            //TempData["MessageDelete"] = "The Product was succesfully deleted";
            return RedirectToAction("AllProducts");
        }

        [HttpGet]
        public IActionResult ProductImageDetails(int id)
        {
            ProductImage productImage = _productRepository.GetProductImageById(id);
            ProductImageViewModel productImageViewModel = _mapper.Map<ProductImageViewModel>(productImage);
            return View(productImageViewModel);
        }

        [HttpGet]
        public IActionResult AddProductImage(int id)
        {
            Product product = _productRepository.GetById(id);
            ProductViewModel productViewModel = _mapper.Map<ProductViewModel>(product);
            if (productViewModel == null)
            {
                return NotFound();
            }
            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProductImage(ProductImageViewModel productImageViewModel , int id)
        {
            Product product = _productRepository.GetById(id);
            var productImage = _mapper.Map<ProductImage>(productImageViewModel);

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
                    productImage.Photo = p1;
                }
                _productRepository.AddProductImage(productImage);
                return RedirectToAction("AddProductImage" , new { id = product.ProductId});
            }
            return View(productImage);
        }

        [HttpGet]
        public IActionResult DeleteProductImage(int id)
        {
            ProductImage productImage = _productRepository.GetProductImageById(id);
            ProductImageViewModel productImageViewModel = _mapper.Map<ProductImageViewModel>(productImage);
            return View(productImageViewModel);
        }

        [HttpPost , ActionName("DeleteProductImage")]
        public IActionResult DeleteProductImageConfirmed(int id)
        {
            _productRepository.DeleteProductImage(id);
            return RedirectToAction("AllProducts" , "Products");
        }





    }
}
