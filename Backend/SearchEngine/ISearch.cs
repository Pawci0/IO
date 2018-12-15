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
   public interface ISearch<T> where T : class
    {
        [OperationContract]
        void Search(string phrase, SortTypeEnum sortType, Dictionary<string, string> filters);
        [OperationContract]
        IEnumerable<T> GetSearchResults();
    }
}
