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
        private ProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }

        // GET: api/Product/5
        public ProductDto Get(int id)
        {
            ProductDto productDto = _productService.GetProduct(id);
            if (productDto != null)
                return productDto;

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // POST: api/Product
        public void Post([FromBody]ProductDto value)
        {
            _productService.CreateProduct(value);
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]ProductDto value)
        {
            _productService.UpdateProduct(value);
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}