using CinemaniaWEB.Models.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaniaWEB.Models.IdentityModels
{
    public class CinemaniaIdentityDbContext
    {
    }
}
public class CinemaniaIdentityDbContext : IdentityDbContext<CinemaniaIdentityUser, CinemaniaIdentityRole, string>
{
    public CinemaniaIdentityDbContext(DbContextOptions<CinemaniaIdentityDbContext> options): base(options)
    {
    }

}