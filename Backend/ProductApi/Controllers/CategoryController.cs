using Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CategoryApi.Controllers
{
    public class CategoryController : ApiController
    {
        private CategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        // GET: api/Category/5
        public CategoryDto Get(int id)
        {
            CategoryDto categoryDto = _categoryService.GetCategory(id);
            if (categoryDto != null)
                return categoryDto;

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // POST: api/Category
        public void Post([FromBody]CategoryDto value)
        {
            _categoryService.CreateCategory(value);
        }

        // PUT: api/Category/5
        public void Put(int id, [FromBody]CategoryDto value)
        {
            _categoryService.UpdateCategory(value);
        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {
            _categoryService.DeleteCategory(id);
        }
    }
}