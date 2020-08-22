using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLater.Entities
{
    public class Bookmark : EntityBase  
    {
        [Key]
        public int ID { get; set; }

        [StringLength(maximumLength: 500)]
        [Required]
        public string URL {get;set;}
        [Required]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
        [Display(Name = "Date Created")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Numbers Clicked")]
        public int ClickCounter { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
