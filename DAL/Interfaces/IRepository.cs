using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T> : IDisposable
    where T : class
    {
        IEnumerable<T> GetAll();
        T GetItem(int id); 
        void Create(T item); 
        void Update(T item); // обновление объекта
        void Delete(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Save(); 
    }
}

