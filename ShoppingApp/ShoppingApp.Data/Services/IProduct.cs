using ShoppingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Services
{
    public interface IProduct
    {
        IEnumerable<Product> Get();
        Product Get(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
