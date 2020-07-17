using Shop.DomainModels.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Data.Repository.IRepository
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<IEnumerable<Order>> GetAllOrdersAsync(string userId);
    }
}
