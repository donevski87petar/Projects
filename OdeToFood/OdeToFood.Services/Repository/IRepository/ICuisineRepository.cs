using OdeToFood.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Services.Repository.IRepository
{
    public interface ICuisineRepository
    {
        Cuisine CreateCuisine(Cuisine cuisine);
        IEnumerable<Cuisine> GetCuisines();
        Cuisine GetCuisine(int cuisineId);
        void UpdateCuisine(Cuisine cuisine);
        void DeleteCuisine(Cuisine cuisine);
    }
}
