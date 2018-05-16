using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class Unit_Of_Works : IUnit_Of_Work,IDisposable
    {

        private Database_Context db;
        private Repository<DB_User> users;
        private Repository<DB_Product> products;
        private Repository<DB_Category> categories;

        public Unit_Of_Works() { db = new Database_Context(); }
        
        public IRepository<DB_User> Users
        {
            get
            {
                if (users == null)
                    users = new Repository<DB_User>();
                return users;
            }
        }
        public IRepository<DB_Category> Categories
        {
            get
            {
                if (categories == null)
                    categories = new Repository<DB_Category>();
                return categories;
            }
        }
        public IRepository<DB_Product> Products
        {
            get
            {
                if (products == null)
                    products = new Repository<DB_Product>();
                return products;
            }
        }
        
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
