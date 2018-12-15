using SearchEngine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SearchEngine
{
    interface ISearch<T> where T : class
    {
        void Search(string phrase, SortTypeEnum sortType, Dictionary<string, string> filters);
        IEnumerable<T> GetSearchResults();
    }
}
