using SearchEngine;
using SearchEngine.DTO;
using SearchEngine.Enums;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SearchEngineAPI.Controllers
{
    public class SearchController : ApiController
    {
        private readonly ICollection<ISearch<ISearchItemDTO>> searchEngines;

        public SearchController()
        {
            searchEngines = new ISearch<ISearchItemDTO>[] {
                new ProductNameSearch(),
                new TagSearch(),
                new RatingSearch(),
                new UserFullnameSearch(),
                new UserUsernameSearch()
            }
            ;
        }

        [HttpGet]
        [Route("api/search/{phrase}/{sortType}/{pageIndex}/{pageSize}")]
        public IEnumerable<ISearchItemDTO>Search(string phrase, string sortType, int pageIndex, int pageSize)
        {
            var result = new List<ISearchItemDTO>();
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
            catch(Exception exception)
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
