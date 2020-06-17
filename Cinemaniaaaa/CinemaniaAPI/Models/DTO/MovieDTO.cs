using CinemaniaAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaniaAPI.Models.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public double Rating { get; set; }
        [DisplayName("Length")]
        public int LengthMin { get; set; }
        [DisplayName("Released")]
        public string ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public byte[] Cover { get; set; }
        public string Description { get; set; }
    }
}
