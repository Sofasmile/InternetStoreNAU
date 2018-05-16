using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public interface IUser_Operation
    {
        void CreateUser(User user);
        void EditUser(User user);
        bool CheckUser(string login, string password);
        User GetUser(int id);
        bool Buy(int id, int userid);

        void Dispose();
    }
}
