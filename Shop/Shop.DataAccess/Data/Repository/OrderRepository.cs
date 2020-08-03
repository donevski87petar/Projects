using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Data.Repository.IRepository;
using Shop.DomainModels.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly ApplicationDbContext _db;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderRepository(
            ApplicationDbContext db,
            IShoppingCartRepository shoppingCartRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _shoppingCartRepository = shoppingCartRepository;
            _httpContextAccessor = httpContextAccessor;
    }

        public async Task CreateOrderAsync(Order order)
        {
            //add the order first
            order.OrderPlacedTime = DateTime.Now;
            order.UserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            order.OrderTotal = (await _shoppingCartRepository.GetCartCountAndTotalAmmountAsync()).TotalAmmount;
            await _db.Orders.AddAsync(order);


            await _db.SaveChangesAsync();

            //add the order items
            var shoppingCartItems = await _shoppingCartRepository.GetShoppingCartItemsAsync();

            await _db.OrderItems.AddRangeAsync(shoppingCartItems.Select(e => new OrderItem
            {
                OrderId = order.OrderId,
                Product = e.Product,
                Quantity = e.Qty,
                Price = e.Product.Price
            }));
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _db.Orders
                .Include(o => o.OrderItems)
                .Select(e => new Order
                {
                    OrderPlacedTime = e.OrderPlacedTime,
                    FullName = e.FullName,
                    Address = e.Address,
                    City = e.City,
                    Country = e.Country,
                    ZipCode = e.ZipCode,
                    PhoneNumber = e.PhoneNumber,
                    OrderTotal = e.OrderTotal,
                    OrderItems = e.OrderItems.Select(o => new OrderItem
                    {
                        Product = o.Product,
                        Price = o.Price,
                        Quantity = o.Quantity
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(string userId)
        {
            return await _db.Orders.Include(o => o.OrderItems) ///////////////////////
                   .Where(e => e.UserId == userId)
                   .Select(e => new Order
                   {
                       OrderPlacedTime = e.OrderPlacedTime,
                       FullName = e.FullName,
                       Address = e.Address,
                       City = e.City,
                       Country = e.Country,
                       ZipCode = e.ZipCode,
                       PhoneNumber = e.PhoneNumber,
                       OrderTotal = e.OrderTotal,
                       OrderItems = e.OrderItems.Select(o => new OrderItem
                       {
                           Product = o.Product,
                           Price = o.Price,
                           Quantity = o.Quantity
                       }).ToList()
                   }).ToListAsync();
        }

    }
}

