using CountriesAppWEB.Models;
using CountriesAppWEB.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CountriesAppWEB.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public CityRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}