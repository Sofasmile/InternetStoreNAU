using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
   public class DB_Product
    {
        [Key]
        [Required]
        public int ProductID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MinLength(5)]
        public string Code { get; set; }
        [Required]
        [MaxLength(20)]
        public int Size { get; set; } /// <summary>
        /// 
        /// </summary>
        public byte[] Image { get; set; }
        [Required]
        [MaxLength(20)]
        public string Colour { get; set; }
        [Required]
        [MaxLength(50)]
        public string Material{ get; set; }
        [MaxLength(50)]
        public string Brend { get; set; }
        [MaxLength(50)]
        public string Season { get; set; }
        [Required]
        public int Price { get; set; }

        [ForeignKey("CategoryID")]
        public DB_Category Category { get; set; }
        public int CategoryID { get; set; }
    }
}
