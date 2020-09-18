using OdeToFood.Data;
using OdeToFood.Domain.Models;
using OdeToFood.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Services.Repository
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private ApplicationDbContext _db;

        public MenuItemRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<MenuItem> GetMenuItems()
        {
            return _db.MenuItems.Include(m => m.Cuisine).Include(m => m.Restaurant).ToList();
        }

        public MenuItem GetMenuItem(int menuItemId)
        {
            return _db.MenuItems.Include(m => m.Cuisine).Include(m => m.Restaurant).FirstOrDefault(m => m.MenuItemId == menuItemId);
        }

        public MenuItem CreateMenuItem(MenuItem menuItem)
        {
            _db.MenuItems.Add(menuItem);
            _db.SaveChanges();
            return menuItem;
        }

        public void DeleteMenuItem(MenuItem menuItem)
        {
            _db.MenuItems.Remove(menuItem);
            _db.SaveChanges();
        }

        public void UpdateMenuItem(MenuItem menuItem)
        {
            var entry = _db.Entry(menuItem);
            entry.State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
