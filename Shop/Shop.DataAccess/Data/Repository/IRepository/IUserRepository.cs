using Shop.DomainModels.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Data.Repository.IRepository
{
    public interface IUserRepository
    {
        ICollection<AppUser> GetAllUsers();
        AppUser GetUserById(string id);
        bool AddUser(AppUser appUserVM);
        bool UpdateUser(AppUser appUserVM);
        bool DeleteUser(string id);
        bool Save();
    }
}
