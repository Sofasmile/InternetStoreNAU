using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
   public class DB_Category
    {
        [Key]
        [Required]
        public int CategoryID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public ICollection<DB_Product> Products { get; set; }
    }
}
