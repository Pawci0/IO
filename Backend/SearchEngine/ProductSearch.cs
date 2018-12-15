using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchEngine.Enums;
using Database;

namespace SearchEngine
{
    internal abstract class ProductSearch : ISearch<Product> 
    {
        protected List<Product> searchResult;
        protected DBManager dataContext = new DBManager();

        public IEnumerable<Product> GetSearchResults()
        {
            if(searchResult == null)
            {
                throw new InvalidOperationException("You haven't searched for anything yet");
            }
            else
            {
                return searchResult;
            }
        }

        public abstract void Search(string phrase, SortTypeEnum sortType, Dictionary<string, string> filters);

        protected void Query()
        {

        }

        protected IEnumerable<Product> OrderBy(IEnumerable<Product> input, SortTypeEnum sortType)
        {
            switch(sortType)
            {
                case SortTypeEnum.ignore:
                    return input;
                case SortTypeEnum.ascending:
                    return input.OrderBy(n => n.Name);
                case SortTypeEnum.descending:
                    return input.OrderByDescending(n => n.Name);
                default:
                    return null;
            }
        }
    }
}
