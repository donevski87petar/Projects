using OdeToFood.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext() : base("OdeToFoodDb")
        {

        }

        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
    }
}
