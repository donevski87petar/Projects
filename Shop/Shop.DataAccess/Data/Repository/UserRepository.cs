using Shop.DataAccess.Data.Repository.IRepository;
using Shop.DomainModels.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.DataAccess.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<AppUser> GetAllUsers()
        {
            return _db.Users.ToList();
        }

        public AppUser GetUserById(string id)
        {
            AppUser appUser = _db.Users.FirstOrDefault(u => u.Id == id);
            return appUser;
        }

        public bool DeleteUser(string id)
        {
            AppUser appUser = _db.Users.FirstOrDefault(u => u.Id == id);
            _db.Remove(appUser);
            return Save();
        }

        public bool AddUser(AppUser appUser)
        {
            _db.Users.Add(appUser);
            return Save();
        }

        public bool UpdateUser(AppUser appUser)
        {
            _db.Users.Update(appUser);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
