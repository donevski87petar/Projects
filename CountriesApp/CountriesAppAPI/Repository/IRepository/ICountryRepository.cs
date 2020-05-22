using CountriesAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesAppAPI.Repository.IRepository
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int CountryId);
        bool CountryExists(string name);
        bool CountryExists(int id);
        bool CreateCountry(Country country);
        bool UpdateCountry(Country country);
        bool DeleteCountry(Country country);
        bool Save();
    }
}
