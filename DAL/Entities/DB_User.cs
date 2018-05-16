using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class DB_User
    {
        [Key]
        [Required]
        public int UserID { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(30)]
        public string Status { get; set; }
        [MaxLength(30)]
        [MinLength(3)]
        public string Login { get; set; }
        [MaxLength(30)]
        [MinLength(3)]
        public string Password { get; set; }

        public ICollection<DB_Product> Products { get; set; }

    }
}
