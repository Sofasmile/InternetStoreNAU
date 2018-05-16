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
    public class CategoryController : ApiController
    {
        IKernel ninject;
        ICategory_Operation COperation;

        public CategoryController()
        {
            ninject = new StandardKernel(new Operation_Module());
            COperation = ninject.Get<ICategory_Operation>();
        }

        [HttpGet]
        [Route("api/GetAllCategories")]/////////////////////////////////////////
        public List<Category> GetAllCategories()
        {
            return COperation.GetAllCategories();
        }

        [HttpPost]
        [Route("api/Categories/CreateCategory/{title}")]///////////////////////////////////
        public IHttpActionResult CreateCategory(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return BadRequest("Заполните корректно все поля.");
            else
            {
                if (COperation.CheckTitle(title))
                    return BadRequest("Kатегория с таким названием уже существует.");
                else
                {
                    COperation.CreateCategory(title);
                    return Ok();
                }

            }
        }

        [HttpDelete]
        [Route("api/Categories/Delete/{id}")]
        public void DeleteCategory(int id)
        {
            COperation.RemoveCategory(id);
        }


        [HttpPost]
        [Route("api/Categories/EditCategory/{category}")]
        public IHttpActionResult EditCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Title))
                return BadRequest("Заполните корректно все поля.");
            else
            {
                if (COperation.CheckTitle(category.Title))
                    return BadRequest("Kатегория с таким названием уже существует.");
                else
                {
                    COperation.EditCategory(category);
                    return Ok();
                }

            }
        }
    }
}
