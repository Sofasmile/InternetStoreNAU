using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Ninject;
using BLL.Infrustructure;

namespace UI.Controllers
{
    public class UserController : ApiController
    {
        IKernel ninject;
        IUser_Operation UOperation;

        public UserController()
        {
            ninject = new StandardKernel(new Operation_Module());
            UOperation = ninject.Get<IUser_Operation>();
        }
        

        [HttpPost]
        [Route("api/Users/CreateUser/{user}")]
        public IHttpActionResult CreateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Status) || string.IsNullOrWhiteSpace(user.Surname)
                || string.IsNullOrWhiteSpace(user.Login) || string.IsNullOrWhiteSpace(user.Password))
                return BadRequest("Заполните корректно все поля.");
            else
            {
                if (UOperation.CheckUser(user.Login,user.Password))
                    return BadRequest("Пользователь уже существует.");
                else
                {
                    UOperation.CreateUser(user);
                    return Ok();
                }

            }
        }
        

        [HttpPost]
        [Route("api/Users/EditUser/{user}")]
        public IHttpActionResult EditUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Status) || string.IsNullOrWhiteSpace(user.Surname)
                || string.IsNullOrWhiteSpace(user.Login) || string.IsNullOrWhiteSpace(user.Password))
                return BadRequest("Заполните корректно все поля.");
            else
            {
                if (UOperation.CheckUser(user.Login, user.Password))
                    return BadRequest("Пользователь уже существует.");
                else
                {
                    UOperation.EditUser(user);
                    return Ok();
                }

            }
        }

        [HttpPost]
        [Route("api/Users/Buy/{userID}/{productID}")]
        public IHttpActionResult Buy(int UserID, int ProductID)
        {
            if (!UOperation.Buy(UserID,ProductID))
                return BadRequest("Товар с таким кодом уже есть в списке покупок пользователя.");
            else
            {
                return Ok();
            }

        }
    }
}