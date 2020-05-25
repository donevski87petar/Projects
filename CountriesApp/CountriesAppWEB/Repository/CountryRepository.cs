using CountriesAppWEB.Models;
using CountriesAppWEB.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CountriesAppWEB.Repository
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public CountryRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
