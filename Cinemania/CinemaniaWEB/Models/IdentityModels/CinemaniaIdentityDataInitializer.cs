using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaniaWEB.Models.IdentityModels
{
    public static class CinemaniaIdentityDataInitializer

    {
        public static void SeedData(UserManager<CinemaniaIdentityUser> userManager, RoleManager<CinemaniaIdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<CinemaniaIdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("user1").Result == null)
            {
                CinemaniaIdentityUser user = new CinemaniaIdentityUser();
                user.UserName = "user1";
                user.Email = "user1@mail.com";
                user.FullName = "Petar Donevski";
                user.BirthDate = new DateTime(1987, 5, 29);

                IdentityResult result = userManager.CreateAsync(user, "Password123.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"User").Wait();
                }
            }


            if (userManager.FindByNameAsync("administrator1").Result == null)
            {
                CinemaniaIdentityUser user = new CinemaniaIdentityUser();
                user.UserName = "administrator1";
                user.Email = "administrator1@mail.com";
                user.FullName = "Petar Donevski";
                user.BirthDate = new DateTime(1987, 5, 29);

                IdentityResult result = userManager.CreateAsync(user, "Password123.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"Administrator").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<CinemaniaIdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                CinemaniaIdentityRole role = new CinemaniaIdentityRole();
                role.Name = "User";
                role.Description = "Perform normal operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                CinemaniaIdentityRole role = new CinemaniaIdentityRole();
                role.Name = "Administrator";
                role.Description = "Perform all the operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
