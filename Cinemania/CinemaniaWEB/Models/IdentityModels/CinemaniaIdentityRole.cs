using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaniaWEB.Models.IdentityModels
{
    public class CinemaniaIdentityRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
