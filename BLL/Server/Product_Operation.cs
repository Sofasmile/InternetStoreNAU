using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using Ninject;
using System.Text.RegularExpressions;

namespace BLL.Server
{
    public class Product_Operation : IProduct_Operation
    {
        string regex=( @"^/d{6}$");
        IKernel ninject;
        IUnit_Of_Work db { get; set; }

        public Product_Operation(IUnit_Of_Work _db)
        {
            db = _db;
        }

        public Product_Operation()
        {
            ninject = new StandardKernel();
            ninject.Bind<IUnit_Of_Work>().To<Unit_Of_Works>();
            db = ninject.Get<IUnit_Of_Work>();
        }

        public bool CheckCode(string code)
        {
            IEnumerable<DB_Product> products = db.Products.GetAll();
            if (Regex.IsMatch(code, regex))
            {
                foreach (DB_Product p in products)
                {
                    if (p.Code == code) return true;
                }
                return false;
            }
            else
                return true;
        }

        public void CreateProduct(Product product,int catid)
        {
            Category category= Mapper.Map<DB_Category, Category>(db.Categories.GetItem(catid));
            var newProduct = new DB_Product()
            {
                Name = product.Name,
                Size = product.Size,
                Image = product.Image,
                Colour = product.Colour,
                Material = product.Material,
                Brend = product.Brend,
                Season = product.Season,
                Price = product.Price,
                Category = db.Categories.GetItem(catid),
                CategoryID = catid
            };

            db.Products.Create(newProduct);
            category.Products.Add(product);
            db.Products.Update(newProduct);
            db.Save();

        }
        
        public void Dispose()
        {
            db.Dispose();
        }

        public void RemoveProduct(int id)
        {
            Product product = Mapper.Map<DB_Product, Product>(db.Products.GetItem(id));
            if (product == null)
                throw new ArgumentNullException();

            Category category = Mapper.Map<DB_Category, Category>(db.Categories.GetItem(product.CategoryID));
            category.Products.Remove(product);
            db.Categories.Update(db.Categories.GetItem(product.CategoryID));
            db.Products.Delete(id);
            db.Save();
        }

        public void EditProduct(Product product)
        {
            var newProduct = new DB_Product()
            {
                Name = product.Name,
                Size = product.Size,
                Image = product.Image,
                Colour = product.Colour,
                Material = product.Material,
                Brend = product.Brend,
                Season = product.Season,
                Price = product.Price,
                Category = db.Categories.GetItem(product.CategoryID),
                CategoryID = product.CategoryID
            };

            db.Categories.Update(db.Categories.GetItem(product.CategoryID));
            db.Products.Update(newProduct);
            db.Save();
        }

        
        public List<Product> Filter(IEnumerable<Product> products, Product product)
        {
            List<Product> prod = new List<Product>();
            foreach(Product p in products)
            {
                if (p == product)
                    prod.Add(p);
            }
            return prod;
        }
        
        public List<Product> GetAllProducts()
        {
            return Mapper.Map < IEnumerable<DB_Product>, List<Product>>(db.Products.GetAll());
        }

        public Product GetProduct(int id)
        {
            return Mapper.Map<DB_Product, Product>(db.Products.GetItem(id));
        }

        
    }
}
