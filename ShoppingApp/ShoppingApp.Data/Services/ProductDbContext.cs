using ShoppingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Services
{
    public class ProductDbContext:DbContext
    {
        //DbSet<Product> Products { get; set; }

        public System.Data.Entity.DbSet<ShoppingApp.Data.Models.Product> Products { get; set; }
    }
}
