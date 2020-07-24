using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Data.Repository.IRepository;
using Shop.DomainModels.Enums;
using Shop.DomainModels.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IShoppingCartRepository _shoppingCart;

        public ShoppingCartController(IProductRepository productRepository, IShoppingCartRepository shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }




        public async Task<IActionResult> CartDetails()
        {
            IEnumerable<ShoppingCartItem> items = await _shoppingCart.GetShoppingCartItemsAsync();

            var shoppingCartCountTotal = await _shoppingCart.GetCartCountAndTotalAmmountAsync();

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCartItems = items,
                ShoppingCartItemsTotal = shoppingCartCountTotal.ItemCount,
                ShoppingCartTotal = shoppingCartCountTotal.TotalAmmount,
            };

            ViewBag.TotalItemsCount = _shoppingCart.GetCartCountAndTotalAmmountAsync().Result.ItemCount;

            return View(shoppingCartViewModel);
        }




        [HttpPost]
        public async Task<IActionResult> AddToShoppingCart(int id )
        {
            Product selectedProduct =  _productRepository.GetById(id);

            if (selectedProduct == null)
            {
                return View("Error");
            }

            await _shoppingCart.AddToCartAsync(selectedProduct);

            return RedirectToAction("CartDetails", "ShoppingCart");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromShoppingCart(int id)
        {
            var selectedProduct = _productRepository.GetById(id);
            if (selectedProduct == null)
            {
                return NotFound();
            }

            await _shoppingCart.RemoveFromCartAsync(selectedProduct);

            return RedirectToAction("CartDetails", "ShoppingCart");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAllCart()
        {
            await _shoppingCart.ClearCartAsync();
            return RedirectToAction("CartDetails");
        }

    }
}
