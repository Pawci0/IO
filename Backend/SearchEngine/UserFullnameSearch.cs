using System.Collections.Generic;
using System.Linq;
using Database;
using SearchEngine.DTO;
using SearchEngine.Enums;

namespace SearchEngine
{
    public class UserFullnameSearch : UserSearch
    {
        public override void Search(string phrase, SortTypeEnum sortType, Dictionary<string, string> filters)
        {
            float score = 0;
            IEnumerable<UserDTO> results = from User user in dataContext.GetAllUsers()
                                            where (user.Name + " " + user.Surname).ContainsFuzzy(phrase, out score)
                                            select new UserDTO(user, score);

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