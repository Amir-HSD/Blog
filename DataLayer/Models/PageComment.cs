using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageComment
    {
        [Key]
        public int PageCommentId { get; set; }
        [Required(ErrorMessage = "Please do not leave the {0} empty")]

        public int PageId { get; set; }
        [Required(ErrorMessage = "Please do not leave the {0} empty")]
        [Display(Name = "CommentName")]
        public string PageCommentName { get; set; }
        [Required(ErrorMessage = "Please do not leave the {0} empty")]
        [Display(Name = "CommentEmail")]
        public string PageCommentEmail { get; set; }
        [Required(ErrorMessage = "Please do not leave the {0} empty")]
        [Display(Name = "CommentText")]
        public string PageCommentText { get; set; }
        [Display(Name = "CommentCreateDate")]
        public DateTime PageCommentCreateDate { get; set; }

        public PageComment()
        {
            
        }

    }
}
