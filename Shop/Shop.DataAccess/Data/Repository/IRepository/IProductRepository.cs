using Shop.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Data.Repository.IRepository
{
    public interface IProductRepository
    {
        ICollection<Product> GetAll();
        Product GetById(int id);
        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
        ProductImage GetProductImageById(int id);
        bool AddProductImage(ProductImage productImage);
        bool DeleteProductImage(int id);
        bool Save();
    }
}
