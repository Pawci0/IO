using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using SearchEngine.Enums;

namespace SearchEngine
{
    internal abstract class UserSearch : SearchBase<User>
    {

        protected IEnumerable<User> OrderBy(IEnumerable<User> input, SortTypeEnum sortType)
        {
            switch (sortType)
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
