using Microsoft.AspNetCore.Identity;
using Shop.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Data.Initializer
{
    public static class IdentityDataInitializer
    {
        public static void SeedData(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<AppUser> userManager)
        {

            if (userManager.FindByNameAsync("user").Result == null)
            {
                AppUser user = new AppUser();
                user.UserName = "user";
                user.Email = "user@mail.com";
                user.FullName = "Petar Donevski";
                user.BirthDate = new DateTime(1987, 1, 1);

                IdentityResult result = userManager.CreateAsync(user, "Password123.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"User").Wait();
                }
            }


            if (userManager.FindByNameAsync("admin").Result == null)
            {
                AppUser user = new AppUser();
                user.UserName = "admin";
                user.Email = "admin@mail.com";
                user.FullName = "Petar Donevski";
                user.BirthDate = new DateTime(1987, 1, 1);

                IdentityResult result = userManager.CreateAsync(user, "Password123.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"Administrator").Wait();
                }
            }

        }

        public static void SeedRoles(RoleManager<AppRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                AppRole role = new AppRole();
                role.Name = "NormalUser";
                role.RoleDescription = "Perform normal operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                AppRole role = new AppRole();
                role.Name = "Administrator";
                role.RoleDescription = "Perform all the operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }


}

