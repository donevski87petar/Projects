using CinemaniaAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaniaAPI.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public double Rating { get; set; }
        public int LengthMin { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public byte[] Cover { get; set; }


    }
}
