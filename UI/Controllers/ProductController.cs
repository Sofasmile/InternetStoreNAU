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
    public class ProductController : ApiController
    {
        IKernel ninject;
        IProduct_Operation POperation;

        public ProductController()
        {
            ninject = new StandardKernel(new Operation_Module());
            POperation = ninject.Get<IProduct_Operation>();
        }


        [HttpGet]
        [Route("api/GetAllProducts")]
        public List<Product> GetAllProducts()
        {
            return POperation.GetAllProducts();
        }

        [HttpPost]
        [Route("api/Products/CreateProduct/{id}/{product}")]///////////////////////////////////
        public IHttpActionResult CreateCategory(Product product, int id)
        {
            if (string.IsNullOrWhiteSpace(product.Name)|| string.IsNullOrWhiteSpace(product.Code) || string.IsNullOrWhiteSpace(product.Colour)||
                string.IsNullOrWhiteSpace(product.Material))
                return BadRequest("Заполните корректно все поля.");
            else
            {
                if (POperation.CheckCode(product.Code))
                    return BadRequest("Товар с таким кодо уже существует либо данные введены не правильно.");
                else
                {
                    POperation.CreateProduct(product,id);
                    return Ok();
                }

            }
        }

        [HttpDelete]
        [Route("api/Products/Delete/{id}")]
        public void Deleteproduct(int id)
        {
            POperation.RemoveProduct(id);
        }


        [HttpPost]
        [Route("api/Products/EditProduct/{product}")]
        public IHttpActionResult EditProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name) || string.IsNullOrWhiteSpace(product.Code) || string.IsNullOrWhiteSpace(product.Colour) ||
                            string.IsNullOrWhiteSpace(product.Material))
                return BadRequest("Заполните корректно все поля.");
            else
            {
                if (POperation.CheckCode(product.Code))
                    return BadRequest("Товар с таким кодом уже существует либо данные введены не правильно.");
                else
                {
                    POperation.EditProduct(product);
                    return Ok();
                }

            }
        }
    }
}
