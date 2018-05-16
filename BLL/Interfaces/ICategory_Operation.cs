using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICategory_Operation
    {
        void CreateCategory(string title);
        bool CheckTitle(string title);
        void RemoveCategory(int id);
        void EditCategory(Category entity);
        List<Category> GetAllCategories();
        Category GetCategory(int id);
        void Dispose();
    }
}
