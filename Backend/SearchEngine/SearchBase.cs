using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using SearchEngine.DTO;
using SearchEngine.Enums;

namespace SearchEngine
{
    internal abstract class SearchBase<T> : ISearch<T> where T : ISearchItemDTO
    {
        protected List<T> searchResult;
        protected readonly DBManager dataContext = new DBManager();


        public IEnumerable<T> GetSearchResults(int skip, int take)
        {
            if(take <= 0)
            {
                throw new ArgumentOutOfRangeException("pageSize can't be lower or equal to zero", nameof(take));
            }
            else if (skip < 0)
            {
                throw new ArgumentOutOfRangeException("pageNumber can't be lower than zero", nameof(skip));
            }
            else if (searchResult == null)
            {
                throw new InvalidOperationException("You haven't searched for anything yet");
            }
            else
            {
                return searchResult.Skip(take * (skip)).Take(take);
            }
        }

        public abstract void Search(string phrase, SortTypeEnum sortType, Dictionary<string, string> filters);

        protected IEnumerable<T> OrderBy(IEnumerable<T> input, SortTypeEnum sortType)
        {
            switch (sortType)
            {
                case SortTypeEnum.ignore:
                    return input.OrderByDescending(n => n.Score);
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
