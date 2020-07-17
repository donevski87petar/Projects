using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.DataAccess.Data.Repository.IRepository;
using Shop.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Data.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {


        private readonly ApplicationDbContext _context;

        public string Id { get; set; }
        public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }

        private ShoppingCartRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public static ShoppingCartRepository GetCart(IServiceProvider services)
        {
            var httpContext = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext;
            var context = services.GetRequiredService<ApplicationDbContext>();

            var request = httpContext.Request;
            var response = httpContext.Response;

            var cardId = request.Cookies["CartId-cookie"] ?? Guid.NewGuid().ToString();

            response.Cookies.Append("CartId-cookie", cardId, new CookieOptions
            {
                Expires = DateTime.Now.AddMonths(2)
            });

            return new ShoppingCartRepository(context)
            {
                Id = cardId
            };
        }

        public async Task<int> AddToCartAsync(Product product, int qty = 1)
        {
            return await AddOrRemoveCart(product, qty);

        }

        public async Task<int> RemoveFromCartAsync(Product product)
        {
            return await AddOrRemoveCart(product, -1);
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItemsAsync()
        {
            ShoppingCartItems = ShoppingCartItems ?? await _context.ShoppingCartItems
                .Where(e => e.ShoppingCartId == Id)
                .Include(e => e.Product)
                .ToListAsync();

            return ShoppingCartItems;
        }

        public async Task ClearCartAsync()
        {
            var shoppingCartItems = _context
                .ShoppingCartItems
                .Where(s => s.ShoppingCartId == Id);

            _context.ShoppingCartItems.RemoveRange(shoppingCartItems);

            ShoppingCartItems = null; //reset
            await _context.SaveChangesAsync();
        }

        public async Task<(int ItemCount, double TotalAmmount)> GetCartCountAndTotalAmmountAsync()
        {
            var subTotal = ShoppingCartItems?
                .Select(c => c.Product.Price * c.Qty) ??
                await _context.ShoppingCartItems
                .Where(c => c.ShoppingCartId == Id)
                .Select(c => c.Product.Price * c.Qty)
                .ToListAsync();

            return (subTotal.Count(),subTotal.Sum());
        }

        private async Task<int> AddOrRemoveCart(Product product, int qty)
        {
            var shoppingCartItem = await _context.ShoppingCartItems
                            .SingleOrDefaultAsync(s => s.ProductId == product.ProductId && s.ShoppingCartId == Id);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = Id,
                    Product = product,
                    Qty = 0
                };

                await _context.ShoppingCartItems.AddAsync(shoppingCartItem);
            }

            shoppingCartItem.Qty += qty;

            if (shoppingCartItem.Qty <= 0)
            {
                shoppingCartItem.Qty = 0;
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }

            await _context.SaveChangesAsync();

            ShoppingCartItems = null; // Reset

            return await Task.FromResult(shoppingCartItem.Qty);
        }


    }
}
