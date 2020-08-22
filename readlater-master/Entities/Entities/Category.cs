using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLater.Entities
{
    public class Category : EntityBase
    {
        [Key]
        public int ID { get; set; }

        [StringLength(maximumLength: 50)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Bookmark> Bookmarks { get; set; }

        public string UserId { get; set; }
    }
}
