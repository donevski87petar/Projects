using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.DomainModels.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        public List<Order> Orders { get; set; }
    }
}
