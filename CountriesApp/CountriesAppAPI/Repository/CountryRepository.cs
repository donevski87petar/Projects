using CountriesAppAPI.Data;
using CountriesAppAPI.Models;
using CountriesAppAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesAppAPI.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _db;

        public CountryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateCountry(Country country)
        {
            _db.Countries.Add(country);
            return Save();
        }

        public bool DeleteCountry(Country country)
        {
            _db.Countries.Remove(country);
            return Save();
        }

        public Country GetCountry(int countryId)
        {
            return _db.Countries.FirstOrDefault(a => a.Id == countryId);
        }

        public ICollection<Country> GetCountries()
        {
            return _db.Countries.OrderBy(a => a.Name).ToList();
        }

        public bool CountryExists(string name)
        {
            bool value = _db.Countries.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool CountryExists(int id)
        {
            return _db.Countries.Any(a => a.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateCountry(Country country)
        {
            _db.Countries.Update(country);
            return Save();
        }
    }
}

