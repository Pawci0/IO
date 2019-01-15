using SearchEngine;
using SearchEngine.DTO;
using SearchEngine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SearchAPI.Controllers
{ 
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductSearchController : ApiController
    {
        private ICollection<ISearch<ProductDTO>> searchEngines;

        public ProductSearchController()
        {
            searchEngines = new ISearch<ProductDTO>[]
            {
                new ProductNameSearch(),
                new TagSearch(),
                new RatingSearch(),
            };
        }

        [HttpGet]
        [Route("api/productsearch/{phrase}/{sortType}/{pageIndex}/{pageSize}")]
        public IEnumerable<ISearchItemDTO> Search(string phrase, string sortType, int pageIndex, int pageSize)
        {
            var result = new List<ProductDTO>();
            try
            {
                var sortTypeEnum = (SortTypeEnum)Enum.Parse(typeof(SortTypeEnum), sortType);
                foreach (var searchEngine in searchEngines)
                {
                    searchEngine.Search(phrase, sortTypeEnum, null);
                    var tmp = searchEngine.GetSearchResults(pageIndex - 1, pageSize);
                    if (tmp != null)
                    {
                        result.AddRange(tmp);
                    }
                }
            }
            catch (Exception exception)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(exception.Message)
                };
                throw new HttpResponseException(message);
            }

            return result;
        }
    }
}