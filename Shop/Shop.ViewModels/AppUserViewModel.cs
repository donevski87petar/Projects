using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.ViewModels
{
    public class AppUserViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
