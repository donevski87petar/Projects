using CountriesAppAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountriesAppAPI.DTOs;

namespace CountriesAppAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<CountriesAppAPI.DTOs.CountryDTO> CountryDTO { get; set; }
    }
}
