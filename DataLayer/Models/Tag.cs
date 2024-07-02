using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    public class Tag
    {

        [Required]
        [Key]
        public int TagId { get; set; }

        [Required]
        [MaxLength(20)]
        public string TagName { get; set; }

        public virtual ICollection<Page> Pages { get; set; }

    }
}
