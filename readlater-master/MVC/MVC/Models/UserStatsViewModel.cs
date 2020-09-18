using ReadLater.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class UserStatsViewModel
    {
        public int Id { get; set; }
        public string URL { get; set; }
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [Display(Name = "Date Created")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Numbers Clicked")]
        public int ClickCounter { get; set; }
        public string PostedByUser { get; set; }

    }
}