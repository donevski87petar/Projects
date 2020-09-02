using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shop.DataAccess.Data.Repository.IRepository;
using Shop.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.DataAccess.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<Product> GetAll()
        {
            return _db.Products.Include(p => p.Images).ToList();
        }

        public Product GetById(int id)
        {
            return _db.Products.Include(i => i.Images).FirstOrDefault(p => p.ProductId == id);
        }

        public bool CreateProduct(Product product)
        {
            _db.Products.Add(product);
            return Save();
        }

        public bool UpdateProduct(Product product)
        {
            _db.Products.Update(product);
            return Save();
        }

        public bool DeleteProduct(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.ProductId == id);
            _db.Products.Remove(product);
            return Save();
        }

        public ProductImage GetProductImageById(int id)
        {
            var image = _db.ProductImages.Include(p => p.Product).FirstOrDefault(i => i.ImageId == id);
            return image;
        }

        public bool AddProductImage(ProductImage productImage)
        {
            _db.ProductImages.Add(productImage);
            return Save();
        }

        public bool DeleteProductImage(int id)
        {
            var image = _db.ProductImages.FirstOrDefault(i => i.ImageId == id);
            _db.ProductImages.Remove(image);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }


    }
}
