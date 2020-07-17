using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Data.Repository.IRepository;
using Shop.DomainModels.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public OrderRepository(
            ApplicationDbContext context,
            IShoppingCartRepository shoppingCartRepository)
        {
            _context = context;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task CreateOrderAsync(Order order)
        {
            order.OrderPlacedTime = DateTime.Now;
            await _context.Orders.AddAsync(order);

            var shoppingCartItems = await _shoppingCartRepository.GetShoppingCartItemsAsync();
            order.OrderTotal = (await _shoppingCartRepository.GetCartCountAndTotalAmmountAsync()).TotalAmmount;

            await _context.OrderDetails.AddRangeAsync(shoppingCartItems.Select(e => new OrderDetail
            {
                Qty = e.Qty,
                ProductName = e.Product.ModelName,
                OrderId = order.Id,
                Price = e.Product.Price
            }));

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(e => e.OrderDetails)
                .Select(e => new Order
                {
                    OrderPlacedTime = e.OrderPlacedTime,

                    FullName = e.FullName,
                    Address = e.Address,
                    City = e.City,
                    Country = e.Country,
                    ZipCode = e.ZipCode,
                    PhoneNumber = e.PhoneNumber,
                    OrderTotal = e.OrderTotal
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(string userId)
        {
            return await _context.Orders
                   .Where(e => e.UserId == userId)
                   .Include(e => e.OrderDetails)
                   .Select(e => new Order
                   {
                       OrderPlacedTime = e.OrderPlacedTime,

                       FullName = e.FullName,
                       Address = e.Address,
                       City = e.City,
                       Country = e.Country,
                       ZipCode = e.ZipCode,
                       PhoneNumber = e.PhoneNumber,
                       OrderTotal = e.OrderTotal
                   })
                   .ToListAsync();
        }

    }
}

