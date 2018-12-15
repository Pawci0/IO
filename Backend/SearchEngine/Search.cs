using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using SearchEngine.Enums;

namespace SearchEngine
{
    internal abstract class SearchBase<T> : ISearch<T> where T : class
    {
        protected List<T> searchResult;
        protected DBManager dataContext = new DBManager();


        public IEnumerable<T> GetSearchResults()
        {
            if (searchResult == null)
            {
                throw new InvalidOperationException("You haven't searched for anything yet");
            }
            else
            {
                return searchResult;
            }
        }

        public abstract void Search(string phrase, SortTypeEnum sortType, Dictionary<string, string> filters);
    }
}
