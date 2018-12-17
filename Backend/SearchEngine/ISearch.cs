using SearchEngine.DTO;
using SearchEngine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine
{
    [ServiceContract]
    public interface ISearch<T> where T : ISearchItemDTO
    {
        [OperationContract]
        void Search(string phrase, SortTypeEnum sortType, Dictionary<string, string> filters);

        /// <summary>
        /// Take pageSize number of search results for pageNumberth page in UI
        /// </summary>
        /// <param name="pageNumber"> Index of page in UI (counted from 1) </param>
        /// <param name="pageSize"> Number of items per page </param>
        /// <returns> IEnumerable with search results with size pageSize </returns>
        [OperationContract]
        IEnumerable<T> GetSearchResults(int pageNumber, int pageSize);
    }
}
