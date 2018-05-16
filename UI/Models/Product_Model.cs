using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;

namespace UI.Models
{
    public class Product_Model
    {
        public int PostID { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int[] Size { get; set; }
        public byte[] Image { get; set; }
        public string Colour { get; set; }
        public string Material { get; set; }
        public string Brend { get; set; }
        public string Season { get; set; }
        public int Price { get; set; }
        public Category Category { get; set; }
        public int CategoryID { get; set; }
    }
}