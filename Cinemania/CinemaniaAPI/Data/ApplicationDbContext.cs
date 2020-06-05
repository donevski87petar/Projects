using CinemaniaAPI.Models;
using CinemaniaAPI.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaniaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }


        //Ceed Database
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Movie>().HasData(
        //        new Movie
        //        {
        //            Title = "Terminator",
        //            Genre = Genre.Action
        //        }
        //        );
        //}


    }
}
