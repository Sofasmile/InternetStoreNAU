using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;

namespace UI.Models
{
    public class Category_Model
    {
        public int CategoryID { get; set; }
        public string Title { get; set; }

        public ICollection<Product_Model> Products { get; set; }
    }
}