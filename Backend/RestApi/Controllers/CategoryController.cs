﻿using ProductModule;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CategoryApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Category")]
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

        [HttpGet]
        [Route("GetAllCategories")]
        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return _categoryService.getAllCategories();
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