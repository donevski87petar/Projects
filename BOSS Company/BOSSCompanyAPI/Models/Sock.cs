using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BOSSCompanyAPI.Models
{
    public class Sock
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Range(0, 2, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal ProductPrice { get; set; }


    }
}
