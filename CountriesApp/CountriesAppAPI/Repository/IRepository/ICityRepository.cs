using CountriesAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesAppAPI.Repository.IRepository
{
    public interface ICityRepository
    {
        ICollection<City> GetCities();
        ICollection<City> GetCitiesInCountry(int countryId);
        City GetCity(int CityId);
        bool CityExists(string name);
        bool CityExists(int id);
        bool CreateCity(City city);
        bool UpdateCity(City city);
        bool DeleteCity(City city);
        bool Save();
    }
}
