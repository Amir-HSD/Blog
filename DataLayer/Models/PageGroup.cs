using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageGroup
    {
        [Key]
        public int PageGroupId { get; set; }

        [Display(Name = "GroupTitle")]
        [Required(ErrorMessage = "Please do not leave the {0} empty")]
        [MaxLength(50)]
        public string PageGroupTitle { get; set; }

        public virtual ICollection<Page> Pages { get; set; }

        public PageGroup()
        {
            
        }
    }
}
