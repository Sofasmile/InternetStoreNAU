using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public interface IProduct_Operation
    {
        void CreateProduct(Product product, int id);
        void RemoveProduct(int id);
        bool CheckCode(string code);
        void EditProduct(Product product);
        Product GetProduct(int id);
        List<Product> Filter(IEnumerable<Product> products, Product product);
        List<Product> GetAllProducts();
        void Dispose();
    }
}
