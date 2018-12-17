using Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ProductApi.Controllers
{
    public class ProductController : ApiController
    {
        private ProductService _userService;

        public ProductController()
        {
            _userService = new ProductService();
        }

        // GET: api/Product/5
        public ProductDto Get(int id)
        {
            ProductDto userDto = _userService.GetProduct(id);
            if (userDto != null)
                return userDto;

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // POST: api/Product
        public void Post([FromBody]ProductDto value)
        {
            _userService.CreateProduct(value);
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]ProductDto value)
        {
            _userService.UpdateProduct(value);
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}