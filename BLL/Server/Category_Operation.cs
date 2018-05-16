using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using AutoMapper;
using Ninject;

namespace BLL.Server
{
   public class Category_Operation : ICategory_Operation
    {
        IKernel ninject;
        IUnit_Of_Work db{ get; set; }

        public Category_Operation(IUnit_Of_Work _db)
        {
            db = _db;
        }
        public Category_Operation()
        {
            ninject = new StandardKernel();
            ninject.Bind<IUnit_Of_Work>().To<Unit_Of_Works>();
            db = ninject.Get<IUnit_Of_Work>();
        }

        public bool CheckTitle(string title)
        {
            IEnumerable<DB_Category> categories = db.Categories.GetAll();
            foreach (DB_Category c in categories)
            {
                if (c.Title == title) return true;
            }
            return false;
        }

        public void CreateCategory(string title)
        {
            db.Categories.Create(new DB_Category { Title = title });
            db.Save();
        }
        public void Dispose()
        {
            db.Dispose();
        }
        public void RemoveCategory(int id)
        {
            DB_Category category = db.Categories.GetItem(id);

            if (category == null)
                throw new ArgumentNullException();

            db.Categories.Delete(id);
            foreach(DB_Product p in category.Products)
            {
                p.Category = null;
            }
            db.Save();
        }
        public void EditCategory(Category entity)
        {
            var temp = db.Categories.GetItem(entity.CategoryID);

            temp.Title = entity.Title;

            db.Categories.Update(temp);
            db.Save();
        }
        public List<Category> GetAllCategories()
        {
            return Mapper.Map<IEnumerable<DB_Category>, List<Category>>(db.Categories.GetAll());
        }

        public Category GetCategory(int id)
        {
            return Mapper.Map<DB_Category, Category>(db.Categories.GetItem(id));
        }
    }
}
