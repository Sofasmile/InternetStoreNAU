using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Category
    {
        public Category() {
            Products = new List<Product>();
        }
        
        public int CategoryID { get; set; }
        public string Title { get; set; }

        public ICollection<Product> Products { get; set; }
        
        public override string ToString()
        {
            return Title;
        }
    }
}
