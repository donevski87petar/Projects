using OdeToFood.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Services.Repository.IRepository
{
    public interface IMenuItemRepository
    {
        MenuItem CreateMenuItem(MenuItem menuItem);
        IEnumerable<MenuItem> GetMenuItems();
        MenuItem GetMenuItem(int menuItemId);
        void UpdateMenuItem(MenuItem menuItem);
        void DeleteMenuItem(MenuItem menuItem);
    }
}
