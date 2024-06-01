using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Page
    {
        [Key]
        public int PageId { get; set; }

        [Required(ErrorMessage = "Please do not leave the {0} empty")]
        [Display(Name = "GroupID")]
        public int PageGroupId { get; set; }

        [Required(ErrorMessage = "Please do not leave the {0} empty")]
        [Display(Name = "Title")]
        [MaxLength(50)]
        public string PageTitle { get; set; }

        [Display(Name = "Description")]
        [MaxLength(255)]
        public string PageDescription { get; set; }

        [Required(ErrorMessage = "Please do not leave the {0} empty")]
        [Display(Name = "Content")]
        public string PageContent { get; set; }

        [Display(Name = "Image")]
        public string PageImage { get; set; }

        [Display(Name = "VisitorCount")]
        public int PageVisitorCount { get; set; }

        [Display(Name = "CreateDate")]
        public DateTime PageCreateDate { get; set; }

        public virtual PageGroup PageGroup { get; set; }

        public virtual ICollection<PageComment> PageComments { get; set; }

        public Page()
        {
            
        }
    }
}
