using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchEngine.Enums;
using Database;

namespace SearchEngine
{
    internal abstract class ProductSearch : SearchBase<Product>
    {

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
