using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Repository<T> : IRepository<T>
        where T:class
    {
        private Database_Context db;

        public Repository()
        {
            this.db = new Database_Context();
        }
        public virtual IEnumerable<T> Get()
        {
            return db.Set<T>().AsNoTracking().ToList();
        }

        public void Create(T item)
        {
            db.Set<T>().Add(item);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            T item = db.Set<T>().Find(id);
            if (item != null)
                db.Set<T>().Remove(item);
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public T GetItem(int id)
        {
            T item = db.Set<T>().Find(id);
            if (item != null)
                return item;
            else
                throw new ArgumentNullException();
        }
        public virtual IEnumerable<T> GetAll()
        {
            IQueryable<T> query = db.Set<T>();
            return query.ToList();
        }
        public void Update(T item) 
        {
            db.Entry(item).State = EntityState.Modified;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing) //Выполняет определяемые приложением задачи, связанные с удалением, высвобождением или сбросом неуправляемых ресурсов.
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<T> Find(Func<T, Boolean> predicate)
        {
            return db.Set<T>().Where(predicate).ToList();
        }
        


    }
}
