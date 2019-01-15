using SearchEngine;
using SearchEngine.DTO;
using SearchEngine.Enums;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SearchEngineAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserSearchController : ApiController
    {
        private readonly ICollection<ISearch<UserDTO>> searchEngines;

        public UserSearchController()
        {
            searchEngines = new ISearch<UserDTO>[] 
            {
                new UserFullnameSearch(),
                new UserUsernameSearch()
            };
        }

        [HttpGet]
        [Route("api/usersearch/{phrase}/{sortType}/{pageIndex}/{pageSize}")]
        public IEnumerable<ISearchItemDTO>Search(string phrase, string sortType, int pageIndex, int pageSize)
        {
            var result = new List<UserDTO>();
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
