using System.Collections.Generic;
using System.Linq;
using Database;
using SearchEngine.Enums;

namespace SearchEngine
{
    internal class UserFullnameSearch : UserSearch
    {
        public override void Search(string phrase, SortTypeEnum sortType, Dictionary<string, string> filters)
        {
            IEnumerable<User> results = from User user in dataContext.GetAllUsers()
                where (user.Name + " " + user.Surname).ContainsFuzzy(phrase)
                select user;

            if (searchResult is null)
            {
                searchResult = OrderBy(results, sortType).ToList();
            }
            else
            {
                searchResult.AddRange(OrderBy(results, sortType));
            }
        }
    }
}