using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnit_Of_Work:IDisposable
    {
        IRepository<DB_User> Users { get; }
        IRepository<DB_Category> Categories { get; }
        IRepository<DB_Product> Products { get; }
        void Save();
    }
}
