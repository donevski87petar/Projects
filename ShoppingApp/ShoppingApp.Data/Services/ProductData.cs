using ShoppingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Services
{
    public class ProductData : IProduct
    {
        public ProductDbContext _db { get; }
        public ProductData(ProductDbContext db)
        {
            _db = db;
        }



        public IEnumerable<Product> Get()
        {
            return _db.Products.ToList().OrderBy(p => p.Model);
        }

        public Product Get(int id)
        {
            return _db.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Product product = _db.Products.FirstOrDefault(p => p.Id == id);
            if(product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            var entry = _db.Entry(product);
            entry.State = EntityState.Modified;
            _db.SaveChanges();
        }


    }
}
