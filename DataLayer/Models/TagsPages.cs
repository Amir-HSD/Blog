using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TagsPages
    {
        [Required]
        [Key]
        public int Id { get; set; }

        
        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }

        
        public  int PageId { get; set; }

        public virtual Page Page { get; set; }
    }
}
