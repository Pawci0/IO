﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using SearchEngine;
using SearchEngine.DTO;
using SearchEngine.Enums;

namespace SearchEngineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private ICollection<ISearch<ISearchItemDTO>> searchEngines;

        public SearchController()
        {
            searchEngines = SearchUtils.GetAllSearchEngines().ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"> Page index, starting with 1 </param>
        /// <param name="pageSize"> Number of items displayed on each page </param>
        /// </param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/getsearchresults/{pageIndex}/{pageSize}")]
        public ActionResult<IEnumerable<ISearchItemDTO>> GetSearchResult(int pageIndex, int pageSize)
        {
            IEnumerable<ISearchItemDTO> result = new ISearchItemDTO[] { };

            int amountOfElementsToTake = (pageSize / searchEngines.Count()) + 1;
            int amountOfEnginesToTakeWholeSubset = pageSize / searchEngines.Count();
            int firstEngine = (pageSize % searchEngines.Count()) * (pageIndex - 1);

            int baseSkip = pageSize * (int)((pageIndex - 1) / searchEngines.Count());
            int full = (pageIndex - 1) % searchEngines.Count;

            int[] skips = Enumerable.Repeat(baseSkip, searchEngines.Count).ToArray();
            int skipsIt = 0;
            while (full != 0)
            {
                ++skips[skipsIt];
                skipsIt = ++skipsIt % skips.Count();
                --full;
            }

            try
            {
                int it = firstEngine, wholeSubsetIt = 0;
                do
                {
                    if (wholeSubsetIt < amountOfEnginesToTakeWholeSubset)
                    {
                        result = result.Concat(searchEngines.ElementAt(it).GetSearchResults(skips[it], amountOfElementsToTake));
                    }
                    else
                    {
                        result = result.Concat(searchEngines.ElementAt(it).GetSearchResults(skips[it], amountOfElementsToTake - 1));
                    }

                    it = ++it % searchEngines.Count();
                }
                while (it != firstEngine);
            }
            catch(ArgumentOutOfRangeException)
            {
                return new StatusCodeResult(416);
            }
            catch(InvalidOperationException)
            {
                return new StatusCodeResult(400);
            }
            return new ActionResult<IEnumerable<ISearchItemDTO>>(result);
        }

        [HttpGet]
        [Route("api/search/{phrase}/{pageSize}")]
        public EmptyResult Search(string phrase, string sortType)
        {
            SortTypeEnum sortTypeEnum = (SortTypeEnum)Enum.Parse(typeof(SortTypeEnum), sortType);
            foreach (var searchEngine in searchEngines)
            {
                searchEngine.Search(phrase, sortTypeEnum, null);
            }
            return new EmptyResult();
        }
    }
}
