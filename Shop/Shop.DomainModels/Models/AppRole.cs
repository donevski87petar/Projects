using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DomainModels.Models
{
    public class AppRole : IdentityRole
    {
        public string RoleDescription { get; set; }
    }
}
