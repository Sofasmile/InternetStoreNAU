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
    public class User_Operation : IUser_Operation
    {
        IKernel ninject;
        IUnit_Of_Work db { get; set; }

        public User_Operation(IUnit_Of_Work _db)
        {
            db = _db;
        }
        public User_Operation()
        {
            ninject = new StandardKernel();
            ninject.Bind<IUnit_Of_Work>().To<Unit_Of_Works>();
            db = ninject.Get<IUnit_Of_Work>();
        }
        public void CreateUser(User user)
        {

            var newUser = new DB_User()
            {
                Name = user.Name,
                Surname = user.Surname,
                Status = user.Status,
                Login = user.Login,
                Password = user.Password
            };

            db.Users.Create(newUser);
            db.Save();
        }
        public bool CheckUser(string login,string password)
        {
            IEnumerable<DB_User> users = db.Users.GetAll();
            foreach (DB_User c in users)
            {
                if (c.Login == login) return true;
                if (c.Password == password) return true;
            }
            return false;
        }
        public void Dispose()
        {
            db.Dispose();
        }
        public User GetUser(int id)
        {
            return Mapper.Map<DB_User, User>(db.Users.GetItem(id));
        }
        public void EditUser(User user)
        {
            var temp = new DB_User()
            {
                Name = user.Name,
                Surname = user.Surname,
                Status = user.Status,
                Login = user.Login,
                Password = user.Password
            };

            db.Users.Update(temp);
            db.Save();
        }
        
        public bool Buy(int id,int userid)
        {
            DB_Product product = db.Products.GetItem(id);
            DB_User user = db.Users.GetItem(userid);

            if (product == null || user == null)
                throw new ArgumentNullException();
            foreach(DB_Product p in user.Products)
            {
                if (p == product)
                    return false;
                else
                {
                    user.Products.Add(product);
                    db.Users.Update(user);
                    db.Save();
                    return true;
                }
            }
            return false;
           
        }
        
    }
}
