using CountriesAppAPI.Data;
using CountriesAppAPI.Models;
using CountriesAppAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesAppAPI.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _db;

        public CityRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateCity(City city)
        {
            _db.Cities.Add(city);
            return Save();
        }



        public bool DeleteCity(City city)
        {
            _db.Cities.Remove(city);
            return Save();
        }



        public City GetCity(int cityId)
        {
            return _db.Cities.Include(c => c.Country).FirstOrDefault(a => a.Id == cityId);
        }

        public ICollection<City> GetCities()
        {
            return _db.Cities.Include(c => c.Country).OrderBy(a => a.Name).ToList();
        }

        public ICollection<City> GetCitiesInCountry(int countryId)
        {
            return _db.Cities.Include(c => c.Country).Where(i => i.CountryId == countryId).ToList();
        }



        public bool CityExists(string name)
        {
            bool value = _db.Cities.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }



        public bool CityExists(int id)
        {
            return _db.Cities.Any(a => a.Id == id);
        }



        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }



        public bool UpdateCity(City city)
        {
            _db.Cities.Update(city);
            return Save();
        }
    }
}

