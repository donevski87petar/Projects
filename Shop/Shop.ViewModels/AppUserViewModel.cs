using Shop.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.ViewModels
{
    public class AppUserViewModel
    {
        [Key]
        public string Id { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }


    }
}
